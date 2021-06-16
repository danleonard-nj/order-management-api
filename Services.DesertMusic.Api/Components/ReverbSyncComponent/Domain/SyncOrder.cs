using System;

namespace Services.DesertMusic.Api.Components.ReverbSyncComponent.Domain
{
		public class SyncOrder
		{
				public DateTime SyncOrderCreatedDate { get; set; }
				public string SyncOrderHashKey { get; set; }
				public decimal? AmountProductAmount { get; set; }
				public int? AmountProductAmountCents { get; set; }
				public string AmountProductCurrency { get; set; }
				public string AmountProductSymbol { get; set; }
				public string AmountProductDisplay { get; set; }
				public decimal? AmountProductSubtotalAmount { get; set; }
				public int? AmountProductSubtotalAmountCents { get; set; }
				public string AmountProductSubtotalCurrency { get; set; }
				public string AmountProductSubtotalSymbol { get; set; }
				public string AmountProductSubtotalDisplay { get; set; }
				public decimal? ShippingAmount { get; set; }
				public int? ShippingAmountCents { get; set; }
				public string ShippingCurrency { get; set; }
				public string ShippingSymbol { get; set; }
				public string ShippingDisplay { get; set; }
				public decimal? AmountTaxAmount { get; set; }
				public int? AmountTaxAmountCents { get; set; }
				public string AmountTaxCurrency { get; set; }
				public string AmountTaxSymbol { get; set; }
				public string AmountTaxDisplay { get; set; }
				public decimal? TotalAmount { get; set; }
				public int? TotalAmountCents { get; set; }
				public string TotalCurrency { get; set; }
				public string TotalSymbol { get; set; }
				public string TotalDisplay { get; set; }
				public string BuyerName { get; set; }
				public string BuyerFirstName { get; set; }
				public string BuyerLastName { get; set; }
				public int? BuyerId { get; set; }
				public DateTime CreatedDate { get; set; }
				public string OrderNumber { get; set; }
				public string OrderSource { get; set; }
				public bool NeedsFeedbackForBuyer { get; set; }
				public bool NeedsFeedbackForSeller { get; set; }
				public string OrderType { get; set; }
				public DateTime? PaidDate { get; set; }
				public int Quantity { get; set; }
				public string ShippingAddressRegion { get; set; }
				public string ShippingAddressLocality { get; set; }
				public string ShippingAddressCountryCode { get; set; }
				public string ShippingAddressDisplayLocation { get; set; }
				public string ShippingAddressId { get; set; }
				public bool? ShippingAddressPrimary { get; set; }
				public string ShippingAddressName { get; set; }
				public string ShippingAddressStreetAddress { get; set; }
				public string ShippingAddressExtendedAddress { get; set; }
				public string ShippingAddressPostalCode { get; set; }
				public string ShippingAddressPhone { get; set; }
				public string ShippingAddressUnformattedPhone { get; set; }
				public bool? ShippingAddressCompleteShippingAddress { get; set; }
				public string ShippingMethod { get; set; }
				public string ShipmentStatus { get; set; }
				public bool LocalPickup { get; set; }
				public string ShopName { get; set; }
				public string Status { get; set; }
				public string Title { get; set; }
				public DateTime UpdatedDate { get; set; }
				public string PaymentMethod { get; set; }
				public string OrderBundleId { get; set; }
				public string ProductId { get; set; }
				public string Uuid { get; set; }
				public decimal? SellingFeeAmount { get; set; }
				public int? SellingFeeAmountCents { get; set; }
				public string SellingFeeCurrency { get; set; }
				public string SellingFeeSymbol { get; set; }
				public string SellingFeeDisplay { get; set; }
				public decimal? DirectCheckoutFeeAmount { get; set; }
				public int? DirectCheckoutFeeAmountCents { get; set; }
				public string DirectCheckoutFeeCurrency { get; set; }
				public string DirectCheckoutFeeSymbol { get; set; }
				public string DirectCheckoutFeeDisplay { get; set; }
				public string TaxResponsibleParty { get; set; }
				public decimal? DirectCheckoutPayoutAmount { get; set; }
				public int? DirectCheckoutPayoutAmountCents { get; set; }
				public string DirectCheckoutPayoutCurrency { get; set; }
				public string DirectCheckoutPayoutSymbol { get; set; }
				public string DirectCheckoutPayoutDisplay { get; set; }
				public DateTime? ShippingDate { get; set; }
				public DateTime? ShipDate { get; set; }
				public string ShippingProvider { get; set; }
				public string ShippingCode { get; set; }
				public string Sku { get; set; }
				public decimal? BumpFeeAmount { get; set; }
				public int? BumpFeeAmountCents { get; set; }
				public string BumpFeeCurrency { get; set; }
				public string BumpFeeSymbol { get; set; }
				public string BumpFeeDisplay { get; set; }


		}

}
