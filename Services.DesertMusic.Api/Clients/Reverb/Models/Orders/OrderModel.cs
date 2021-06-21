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


using Newtonsoft.Json;
using System;

namespace Services.DesertMusic.Api.Clients.Reverb.Models.Orders
{
		public class OrderModel
		{
				[JsonProperty(PropertyName = "amount_product")]
				public OrderAmountModel AmountProduct { get; set; }

				[JsonProperty(PropertyName = "amount_product_subtotal")]
				public OrderAmountModel AmountProductSubtotal { get; set; }

				[JsonProperty(PropertyName = "shipping")]
				public OrderAmountModel Shipping { get; set; }

				[JsonProperty(PropertyName = "amount_tax")]
				public OrderAmountModel AmountTax { get; set; }

				[JsonProperty(PropertyName = "total")]
				public OrderAmountModel Total { get; set; }

				[JsonProperty(PropertyName = "buyer_name")]
				public string BuyerName { get; set; }

				[JsonProperty(PropertyName = "buyer_first_name")]
				public string BuyerFirstName { get; set; }

				[JsonProperty(PropertyName = "buyer_last_name")]
				public string BuyerLastName { get; set; }

				[JsonProperty(PropertyName = "buyer_id")]
				public int? BuyerId { get; set; }

				[JsonProperty(PropertyName = "created_at")]
				public DateTime CreatedDate { get; set; }

				[JsonProperty(PropertyName = "order_number")]
				public string OrderNumber { get; set; }

				[JsonProperty(PropertyName = "order_source")]
				public string OrderSource { get; set; }

				[JsonProperty(PropertyName = "needs_feedback_for_buyer")]
				public bool NeedsFeedbackForBuyer { get; set; }

				[JsonProperty(PropertyName = "needs_feedback_for_seller")]
				public bool NeedsFeedbackForSeller { get; set; }

				[JsonProperty(PropertyName = "order_type")]
				public string OrderType { get; set; }

				[JsonProperty(PropertyName = "paid_at")]
				public DateTime? PaidDate { get; set; }

				[JsonProperty(PropertyName = "quantity")]
				public int Quantity { get; set; }

				[JsonProperty(PropertyName = "shipping_address")]
				public OrderAddressModel ShippingAddress { get; set; }

				[JsonProperty(PropertyName = "shipping_method")]
				public string ShippingMethod { get; set; }

				[JsonProperty(PropertyName = "shipment_status")]
				public string ShipmentStatus { get; set; }

				[JsonProperty(PropertyName = "local_pickup")]
				public bool LocalPickup { get; set; }

				[JsonProperty(PropertyName = "shop_name")]
				public string ShopName { get; set; }

				[JsonProperty(PropertyName = "status")]
				public string Status { get; set; }

				[JsonProperty(PropertyName = "title")]
				public string Title { get; set; }

				[JsonProperty(PropertyName = "updated_at")]
				public DateTime UpdatedDate { get; set; }

				[JsonProperty(PropertyName = "payment_method")]
				public string PaymentMethod { get; set; }

				[JsonProperty(PropertyName = "order_bundle_id")]
				public string OrderBundleId { get; set; }

				[JsonProperty(PropertyName = "product_id")]
				public string ProductId { get; set; }

				[JsonProperty(PropertyName = "uuid")]
				public string UUID { get; set; }

				[JsonProperty(PropertyName = "selling_fee")]
				public OrderAmountModel SellingFee { get; set; }

				[JsonProperty(PropertyName = "direct_checkout_fee")]
				public OrderAmountModel DirectCheckoutFee { get; set; }

				[JsonProperty(PropertyName = "tax_responsible_party")]
				public string TaxResponsibleParty { get; set; }

				[JsonProperty(PropertyName = "direct_checkout_payout")]
				public OrderAmountModel DirectCheckoutPayout { get; set; }

				[JsonProperty(PropertyName = "order_notes")]
				public string[] OrderNotes { get; set; }

				[JsonProperty(PropertyName = "shipping_date")]
				public string ShippingDate { get; set; }

				[JsonProperty(PropertyName = "shipped_at")]
				public DateTime? ShipDate { get; set; }

				[JsonProperty(PropertyName = "shipping_provider")]
				public string ShippingProvider { get; set; }

				[JsonProperty(PropertyName = "shipping_code")]
				public string ShippingCode { get; set; }

				[JsonProperty(PropertyName = "sku")]
				public string SKU { get; set; }

				[JsonProperty(PropertyName = "bump_fee")]
				public OrderAmountModel BumpFee { get; set; }
		}
}
