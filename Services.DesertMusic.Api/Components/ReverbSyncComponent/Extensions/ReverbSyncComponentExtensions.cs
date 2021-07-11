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


using Common.Utilities.Extensions.Type;
using Services.DesertMusic.Api.Clients.Reverb.Models.Orders;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Domain;
using Services.DesertMusic.Api.Utilities.Cryptography;
using System;

namespace Services.DesertMusic.Api.Components.ReverbSyncComponent.Extensions
{
		public static class ReverbSyncComponentExtensions
		{
				public static SyncOrder ToSyncOrder(this OrderModel order)
				{
						var syncOrder = new SyncOrder
						{
								SyncOrderCreatedDate = DateTime.Now,
								SyncOrderHashKey = order.GetHash(),
								AmountProductAmount = order?.AmountProduct?.Amount?.AsType<decimal>(),
								AmountProductAmountCents = order?.AmountProduct?.AmountCents,
								AmountProductCurrency = order?.AmountProduct?.Currency,
								AmountProductSymbol = order?.AmountProduct?.Symbol,
								AmountProductDisplay = order?.AmountProduct?.Display,
								AmountProductSubtotalAmount = order?.AmountProductSubtotal?.Amount?.AsType<decimal>(),
								AmountProductSubtotalAmountCents = order?.AmountProductSubtotal?.AmountCents,
								AmountProductSubtotalCurrency = order?.AmountProductSubtotal?.Currency,
								AmountProductSubtotalSymbol = order?.AmountProductSubtotal?.Symbol,
								AmountProductSubtotalDisplay = order?.AmountProductSubtotal?.Display,
								ShippingAmount = order?.Shipping?.Amount?.AsType<decimal>(),
								ShippingAmountCents = order?.Shipping?.AmountCents,
								ShippingCurrency = order?.Shipping?.Currency,
								ShippingSymbol = order?.Shipping?.Symbol,
								ShippingDisplay = order?.Shipping?.Display,
								AmountTaxAmount = order?.AmountTax?.Amount?.AsType<decimal>(),
								AmountTaxAmountCents = order?.AmountTax?.AmountCents,
								AmountTaxCurrency = order?.AmountTax?.Currency,
								AmountTaxSymbol = order?.AmountTax?.Symbol,
								AmountTaxDisplay = order?.AmountTax?.Display,
								TotalAmount = order?.Total?.Amount?.AsType<decimal>(),
								TotalAmountCents = order?.Total?.AmountCents,
								TotalCurrency = order?.Total?.Currency,
								TotalSymbol = order?.Total?.Symbol,
								TotalDisplay = order?.Total?.Display,
								BuyerName = order.BuyerName,
								BuyerFirstName = order.BuyerFirstName,
								BuyerLastName = order.BuyerLastName,
								BuyerId = order?.BuyerId,
								CreatedDate = order.CreatedDate,
								OrderNumber = order.OrderNumber,
								OrderSource = order.OrderSource,
								NeedsFeedbackForBuyer = order.NeedsFeedbackForBuyer,
								NeedsFeedbackForSeller = order.NeedsFeedbackForSeller,
								OrderType = order.OrderType,
								PaidDate = order?.PaidDate,
								Quantity = order.Quantity,
								ShippingAddressRegion = order?.ShippingAddress?.Region,
								ShippingAddressLocality = order?.ShippingAddress?.Locality,
								ShippingAddressCountryCode = order?.ShippingAddress?.CountryCode,
								ShippingAddressDisplayLocation = order?.ShippingAddress?.DisplayLocation,
								ShippingAddressId = order?.ShippingAddress?.Id,
								ShippingAddressPrimary = order?.ShippingAddress?.Primary,
								ShippingAddressName = order?.ShippingAddress?.Name,
								ShippingAddressStreetAddress = order?.ShippingAddress?.StreetAddress,
								ShippingAddressExtendedAddress = order?.ShippingAddress?.ExtendedAddress?.NullIfEmpty(),
								ShippingAddressPostalCode = order?.ShippingAddress?.PostalCode,
								ShippingAddressPhone = order?.ShippingAddress?.Phone,
								ShippingAddressUnformattedPhone = order?.ShippingAddress?.UnformattedPhone,
								ShippingAddressCompleteShippingAddress = order?.ShippingAddress?.CompleteShippingAddress,
								ShippingMethod = order.ShippingMethod,
								ShipmentStatus = order.ShipmentStatus,
								LocalPickup = order.LocalPickup,
								ShopName = order.ShopName,
								Status = order.Status,
								Title = order.Title,
								UpdatedDate = order.UpdatedDate,
								PaymentMethod = order.PaymentMethod,
								OrderBundleId = order.OrderBundleId,
								ProductId = order.ProductId,
								Uuid = order.UUID,
								SellingFeeAmount = order?.SellingFee?.Amount?.AsType<decimal>(),
								SellingFeeAmountCents = order?.SellingFee?.AmountCents,
								SellingFeeCurrency = order?.SellingFee?.Currency,
								SellingFeeSymbol = order?.SellingFee?.Symbol,
								SellingFeeDisplay = order?.SellingFee?.Display,
								DirectCheckoutFeeAmount = order?.DirectCheckoutFee?.Amount?.AsType<decimal>(),
								DirectCheckoutFeeAmountCents = order?.DirectCheckoutFee?.AmountCents,
								DirectCheckoutFeeCurrency = order?.DirectCheckoutFee?.Currency,
								DirectCheckoutFeeSymbol = order?.DirectCheckoutFee?.Symbol,
								DirectCheckoutFeeDisplay = order?.DirectCheckoutFee?.Display,
								TaxResponsibleParty = order.TaxResponsibleParty,
								DirectCheckoutPayoutAmount = order?.DirectCheckoutPayout?.Amount?.AsType<decimal>(),
								DirectCheckoutPayoutAmountCents = order?.DirectCheckoutPayout?.AmountCents,
								DirectCheckoutPayoutCurrency = order?.DirectCheckoutPayout?.Currency,
								DirectCheckoutPayoutSymbol = order?.DirectCheckoutPayout?.Symbol,
								DirectCheckoutPayoutDisplay = order?.DirectCheckoutPayout?.Display,
								//ShippingDate = order.ShippingDate.AsType<DateTime>(),
								ShipDate = order?.ShipDate,
								ShippingProvider = order.ShippingProvider,
								ShippingCode = order.ShippingCode,
								Sku = order.SKU,
								BumpFeeAmount = order?.BumpFee?.Amount?.AsType<decimal>(),
								BumpFeeAmountCents = order?.BumpFee?.AmountCents,
								BumpFeeCurrency = order?.BumpFee?.Currency,
								BumpFeeSymbol = order?.BumpFee?.Symbol,
								BumpFeeDisplay = order?.BumpFee?.Display,
						};

						return syncOrder;
				}

				public static string GetHash(this object obj)
				{
						var hash = Hasher.CreateHash(obj);

						return hash;
				}

				public static string NullIfEmpty(this string value)
				{
						return string.IsNullOrWhiteSpace(value) ? null : value;
				}

				public static object ToSqlParams(this SyncOrder order)
				{
						var _params = new
						{
								order.SyncOrderHashKey,
								order.AmountProductAmount,
								order.AmountProductAmountCents,
								order.AmountProductCurrency,
								order.AmountProductSymbol,
								order.AmountProductDisplay,
								order.AmountProductSubtotalAmount,
								order.AmountProductSubtotalAmountCents,
								order.AmountProductSubtotalCurrency,
								order.AmountProductSubtotalSymbol,
								order.AmountProductSubtotalDisplay,
								order.ShippingAmount,
								order.ShippingAmountCents,
								order.ShippingCurrency,
								order.ShippingSymbol,
								order.ShippingDisplay,
								order.AmountTaxAmount,
								order.AmountTaxAmountCents,
								order.AmountTaxCurrency,
								order.AmountTaxSymbol,
								order.AmountTaxDisplay,
								order.TotalAmount,
								order.TotalAmountCents,
								order.TotalCurrency,
								order.TotalSymbol,
								order.TotalDisplay,
								order.BuyerName,
								order.BuyerFirstName,
								order.BuyerLastName,
								order.BuyerId,
								order.CreatedDate,
								order.OrderNumber,
								order.OrderSource,
								order.NeedsFeedbackForBuyer,
								order.NeedsFeedbackForSeller,
								order.OrderType,
								order.PaidDate,
								order.Quantity,
								order.ShippingAddressRegion,
								order.ShippingAddressLocality,
								order.ShippingAddressCountryCode,
								order.ShippingAddressDisplayLocation,
								order.ShippingAddressId,
								order.ShippingAddressPrimary,
								order.ShippingAddressName,
								order.ShippingAddressStreetAddress,
								order.ShippingAddressExtendedAddress,
								order.ShippingAddressPostalCode,
								order.ShippingAddressPhone,
								order.ShippingAddressUnformattedPhone,
								order.ShippingAddressCompleteShippingAddress,
								order.ShippingMethod,
								order.ShipmentStatus,
								order.LocalPickup,
								order.ShopName,
								order.Status,
								order.Title,
								order.UpdatedDate,
								order.PaymentMethod,
								order.OrderBundleId,
								order.ProductId,
								order.Uuid,
								order.SellingFeeAmount,
								order.SellingFeeAmountCents,
								order.SellingFeeCurrency,
								order.SellingFeeSymbol,
								order.SellingFeeDisplay,
								order.DirectCheckoutFeeAmount,
								order.DirectCheckoutFeeAmountCents,
								order.DirectCheckoutFeeCurrency,
								order.DirectCheckoutFeeSymbol,
								order.DirectCheckoutFeeDisplay,
								order.TaxResponsibleParty,
								order.DirectCheckoutPayoutAmount,
								order.DirectCheckoutPayoutAmountCents,
								order.DirectCheckoutPayoutCurrency,
								order.DirectCheckoutPayoutSymbol,
								order.DirectCheckoutPayoutDisplay,
								order.ShippingDate,
								order.ShipDate,
								order.ShippingProvider,
								order.ShippingCode,
								order.Sku,
								order.BumpFeeAmount,
								order.BumpFeeAmountCents,
								order.BumpFeeCurrency,
								order.BumpFeeSymbol,
								order.BumpFeeDisplay
						};

						return _params;	
				}
		}
}
