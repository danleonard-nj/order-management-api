/* Copyright (C) 2012, 2013 Dan Leonard
 * 
 * This is free software: you can redistribute it and/or modify it under 
 * the terms of the GNU General Public License as published by the Free 
 * Software Foundation, either version 3 of the License, or (at your option) 
 * any later version.
 * 
 * This software is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License 
 * for more details.
 */


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
