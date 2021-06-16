using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Utilities.Threading
{
		public static class SemaphoreBuilder
		{
				public static async Task<IEnumerable<R>> RunConcurrent<T, R>(this IEnumerable<T> items, Func<T, Task<R>> action, int concurrency = 8)
				{
						var results = new List<R>();
						
						using (var semaphore = new SemaphoreSlim(concurrency, concurrency * 2))
						{
								var tasks = items.Select(async item =>
								{
										await semaphore.WaitAsync();

										try
										{
												var result = await action(item);

												results.Add(result);
										}

										finally
										{
												semaphore.Release();
										}
								});

								await Task.WhenAll(tasks);
						}

						return results;
				}

				public static async Task RunConcurrent<T>(this IEnumerable<T> items, Func<T, Task> action, int concurrency = 8)
				{
						using (var semaphore = new SemaphoreSlim(concurrency, concurrency * 2))
						{
								var tasks = items.Select(async item =>
								{
										await semaphore.WaitAsync();

										try
										{
												await action(item);
										}

										finally
										{
												semaphore.Release();
										}
								});

								await Task.WhenAll(tasks);
						}
				}
		}
}
