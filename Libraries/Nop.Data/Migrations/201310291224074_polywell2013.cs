namespace Nop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polywell2013 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackInStockSubscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerGuid = c.Guid(nullable: false),
                        Username = c.String(maxLength: 1000),
                        Email = c.String(maxLength: 1000),
                        Password = c.String(),
                        PasswordFormatId = c.Int(nullable: false),
                        PasswordSalt = c.String(),
                        AdminComment = c.String(),
                        IsTaxExempt = c.Boolean(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        IsSystemAccount = c.Boolean(nullable: false),
                        SystemName = c.String(),
                        LastIpAddress = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        LastLoginDateUtc = c.DateTime(),
                        LastActivityDateUtc = c.DateTime(nullable: false),
                        BillingAddress_Id = c.Int(),
                        ShippingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddress_Id)
                .ForeignKey("dbo.Address", t => t.ShippingAddress_Id)
                .Index(t => t.BillingAddress_Id)
                .Index(t => t.ShippingAddress_Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Company = c.String(),
                        CountryId = c.Int(),
                        StateProvinceId = c.Int(),
                        City = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        ZipPostalCode = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .ForeignKey("dbo.StateProvince", t => t.StateProvinceId)
                .Index(t => t.CountryId)
                .Index(t => t.StateProvinceId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        AllowsBilling = c.Boolean(nullable: false),
                        AllowsShipping = c.Boolean(nullable: false),
                        TwoLetterIsoCode = c.String(maxLength: 2),
                        ThreeLetterIsoCode = c.String(maxLength: 3),
                        NumericIsoCode = c.Int(nullable: false),
                        SubjectToVat = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingMethod",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        Description = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StateProvince",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Abbreviation = c.String(maxLength: 100),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.CustomerRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        FreeShipping = c.Boolean(nullable: false),
                        TaxExempt = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        IsSystemRole = c.Boolean(nullable: false),
                        SystemName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SystemName = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalAuthenticationRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Email = c.String(),
                        ExternalIdentifier = c.String(),
                        ExternalDisplayIdentifier = c.String(),
                        OAuthToken = c.String(),
                        OAuthAccessToken = c.String(),
                        ProviderSystemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ReturnRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        OrderItemId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ReasonForReturn = c.String(nullable: false),
                        RequestedAction = c.String(nullable: false),
                        CustomerComments = c.String(),
                        StaffNotes = c.String(),
                        ReturnRequestStatusId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.RewardPointsHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        PointsBalance = c.Int(nullable: false),
                        UsedAmount = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Message = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UsedWithOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.UsedWithOrder_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.UsedWithOrder_Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderGuid = c.Guid(nullable: false),
                        StoreId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        BillingAddressId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(),
                        OrderStatusId = c.Int(nullable: false),
                        ShippingStatusId = c.Int(nullable: false),
                        PaymentStatusId = c.Int(nullable: false),
                        PaymentMethodSystemName = c.String(),
                        CustomerCurrencyCode = c.String(),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 8),
                        CustomerTaxDisplayTypeId = c.Int(nullable: false),
                        VatNumber = c.String(),
                        OrderSubtotalInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderSubtotalExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderSubTotalDiscountInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderSubTotalDiscountExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderShippingInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderShippingExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        PaymentMethodAdditionalFeeInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        PaymentMethodAdditionalFeeExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        TaxRates = c.String(),
                        OrderTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderDiscount = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 4),
                        RefundedAmount = c.Decimal(nullable: false, precision: 18, scale: 4),
                        RewardPointsWereAdded = c.Boolean(nullable: false),
                        CheckoutAttributeDescription = c.String(),
                        CheckoutAttributesXml = c.String(),
                        CustomerLanguageId = c.Int(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                        CustomerIp = c.String(),
                        AllowStoringCreditCardNumber = c.Boolean(nullable: false),
                        CardType = c.String(),
                        CardName = c.String(),
                        CardNumber = c.String(),
                        MaskedCreditCardNumber = c.String(),
                        CardCvv2 = c.String(),
                        CardExpirationMonth = c.String(),
                        CardExpirationYear = c.String(),
                        AuthorizationTransactionId = c.String(),
                        AuthorizationTransactionCode = c.String(),
                        AuthorizationTransactionResult = c.String(),
                        CaptureTransactionId = c.String(),
                        CaptureTransactionResult = c.String(),
                        SubscriptionTransactionId = c.String(),
                        PurchaseOrderNumber = c.String(),
                        PaidDateUtc = c.DateTime(),
                        ShippingMethod = c.String(),
                        ShippingRateComputationMethodSystemName = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShippingAddressId);
            
            CreateTable(
                "dbo.DiscountUsageHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscountId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discount", t => t.DiscountId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DiscountTypeId = c.Int(nullable: false),
                        UsePercentage = c.Boolean(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 4),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 4),
                        StartDateUtc = c.DateTime(),
                        EndDateUtc = c.DateTime(),
                        RequiresCouponCode = c.Boolean(nullable: false),
                        CouponCode = c.String(maxLength: 100),
                        DiscountLimitationId = c.Int(nullable: false),
                        LimitationTimes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        Description = c.String(),
                        CategoryTemplateId = c.Int(nullable: false),
                        MetaKeywords = c.String(maxLength: 400),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(maxLength: 400),
                        ParentCategoryId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                        PageSize = c.Int(nullable: false),
                        AllowCustomersToSelectPageSize = c.Boolean(nullable: false),
                        PageSizeOptions = c.String(maxLength: 200),
                        PriceRanges = c.String(maxLength: 400),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        HasDiscountsApplied = c.Boolean(nullable: false),
                        SubjectToAcl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductTypeId = c.Int(nullable: false),
                        ParentGroupedProductId = c.Int(nullable: false),
                        VisibleIndividually = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 400),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        AdminComment = c.String(),
                        ProductTemplateId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        MetaKeywords = c.String(maxLength: 400),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(maxLength: 400),
                        AllowCustomerReviews = c.Boolean(nullable: false),
                        ApprovedRatingSum = c.Int(nullable: false),
                        NotApprovedRatingSum = c.Int(nullable: false),
                        ApprovedTotalReviews = c.Int(nullable: false),
                        NotApprovedTotalReviews = c.Int(nullable: false),
                        SubjectToAcl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        Sku = c.String(maxLength: 400),
                        ManufacturerPartNumber = c.String(maxLength: 400),
                        Gtin = c.String(maxLength: 400),
                        IsGiftCard = c.Boolean(nullable: false),
                        GiftCardTypeId = c.Int(nullable: false),
                        RequireOtherProducts = c.Boolean(nullable: false),
                        RequiredProductIds = c.String(maxLength: 1000),
                        AutomaticallyAddRequiredProducts = c.Boolean(nullable: false),
                        IsDownload = c.Boolean(nullable: false),
                        DownloadId = c.Int(nullable: false),
                        UnlimitedDownloads = c.Boolean(nullable: false),
                        MaxNumberOfDownloads = c.Int(nullable: false),
                        DownloadExpirationDays = c.Int(),
                        DownloadActivationTypeId = c.Int(nullable: false),
                        HasSampleDownload = c.Boolean(nullable: false),
                        SampleDownloadId = c.Int(nullable: false),
                        HasUserAgreement = c.Boolean(nullable: false),
                        UserAgreementText = c.String(),
                        IsRecurring = c.Boolean(nullable: false),
                        RecurringCycleLength = c.Int(nullable: false),
                        RecurringCyclePeriodId = c.Int(nullable: false),
                        RecurringTotalCycles = c.Int(nullable: false),
                        IsShipEnabled = c.Boolean(nullable: false),
                        IsFreeShipping = c.Boolean(nullable: false),
                        AdditionalShippingCharge = c.Decimal(nullable: false, precision: 18, scale: 4),
                        DeliveryDateId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        IsTaxExempt = c.Boolean(nullable: false),
                        TaxCategoryId = c.Int(nullable: false),
                        ManageInventoryMethodId = c.Int(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                        DisplayStockAvailability = c.Boolean(nullable: false),
                        DisplayStockQuantity = c.Boolean(nullable: false),
                        MinStockQuantity = c.Int(nullable: false),
                        LowStockActivityId = c.Int(nullable: false),
                        NotifyAdminForQuantityBelow = c.Int(nullable: false),
                        BackorderModeId = c.Int(nullable: false),
                        AllowBackInStockSubscriptions = c.Boolean(nullable: false),
                        OrderMinimumQuantity = c.Int(nullable: false),
                        OrderMaximumQuantity = c.Int(nullable: false),
                        AllowedQuantities = c.String(maxLength: 1000),
                        DisableBuyButton = c.Boolean(nullable: false),
                        DisableWishlistButton = c.Boolean(nullable: false),
                        AvailableForPreOrder = c.Boolean(nullable: false),
                        PreOrderAvailabilityStartDateTimeUtc = c.DateTime(),
                        CallForPrice = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        ProductCost = c.Decimal(nullable: false, precision: 18, scale: 4),
                        SpecialPrice = c.Decimal(precision: 18, scale: 4),
                        SpecialPriceStartDateTimeUtc = c.DateTime(),
                        SpecialPriceEndDateTimeUtc = c.DateTime(),
                        CustomerEntersPrice = c.Boolean(nullable: false),
                        MinimumCustomerEnteredPrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        MaximumCustomerEnteredPrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        HasTierPrices = c.Boolean(nullable: false),
                        HasDiscountsApplied = c.Boolean(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Width = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 4),
                        AvailableStartDateTimeUtc = c.DateTime(),
                        AvailableEndDateTimeUtc = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product_Category_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsFeaturedProduct = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product_Manufacturer_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        IsFeaturedProduct = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        Description = c.String(),
                        ManufacturerTemplateId = c.Int(nullable: false),
                        MetaKeywords = c.String(maxLength: 400),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(maxLength: 400),
                        PictureId = c.Int(nullable: false),
                        PageSize = c.Int(nullable: false),
                        AllowCustomersToSelectPageSize = c.Boolean(nullable: false),
                        PageSizeOptions = c.String(maxLength: 200),
                        PriceRanges = c.String(maxLength: 400),
                        SubjectToAcl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product_Picture_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Picture", t => t.PictureId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.PictureId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PictureBinary = c.Binary(),
                        MimeType = c.String(nullable: false, maxLength: 40),
                        SeoFilename = c.String(maxLength: 300),
                        IsNew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Title = c.String(),
                        ReviewText = c.String(),
                        Rating = c.Int(nullable: false),
                        HelpfulYesTotal = c.Int(nullable: false),
                        HelpfulNoTotal = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductReviewHelpfulness",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductReviewId = c.Int(nullable: false),
                        WasHelpful = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductReview", t => t.ProductReviewId, cascadeDelete: true)
                .Index(t => t.ProductReviewId);
            
            CreateTable(
                "dbo.Product_SpecificationAttribute_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SpecificationAttributeOptionId = c.Int(nullable: false),
                        CustomValue = c.String(maxLength: 4000),
                        AllowFiltering = c.Boolean(nullable: false),
                        ShowOnProductPage = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SpecificationAttributeOption", t => t.SpecificationAttributeOptionId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SpecificationAttributeOptionId);
            
            CreateTable(
                "dbo.SpecificationAttributeOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecificationAttributeId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecificationAttribute", t => t.SpecificationAttributeId, cascadeDelete: true)
                .Index(t => t.SpecificationAttributeId);
            
            CreateTable(
                "dbo.SpecificationAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductVariantAttributeCombination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AttributesXml = c.String(),
                        StockQuantity = c.Int(nullable: false),
                        AllowOutOfStockOrders = c.Boolean(nullable: false),
                        Sku = c.String(maxLength: 400),
                        ManufacturerPartNumber = c.String(maxLength: 400),
                        Gtin = c.String(maxLength: 400),
                        OverriddenPrice = c.Decimal(precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product_ProductAttribute_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductAttributeId = c.Int(nullable: false),
                        TextPrompt = c.String(),
                        IsRequired = c.Boolean(nullable: false),
                        AttributeControlTypeId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttribute", t => t.ProductAttributeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.ProductAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductVariantAttributeValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductVariantAttributeId = c.Int(nullable: false),
                        AttributeValueTypeId = c.Int(nullable: false),
                        AssociatedProductId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 400),
                        ColorSquaresRgb = c.String(maxLength: 100),
                        PriceAdjustment = c.Decimal(nullable: false, precision: 18, scale: 4),
                        WeightAdjustment = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Quantity = c.Int(nullable: false),
                        IsPreSelected = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product_ProductAttribute_Mapping", t => t.ProductVariantAttributeId, cascadeDelete: true)
                .Index(t => t.ProductVariantAttributeId);
            
            CreateTable(
                "dbo.TierPrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        CustomerRoleId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerRoleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.DiscountRequirement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscountId = c.Int(nullable: false),
                        DiscountRequirementRuleSystemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discount", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.DiscountId);
            
            CreateTable(
                "dbo.GiftCardUsageHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GiftCardId = c.Int(nullable: false),
                        UsedWithOrderId = c.Int(nullable: false),
                        UsedValue = c.Decimal(nullable: false, precision: 18, scale: 4),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GiftCard", t => t.GiftCardId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.UsedWithOrderId, cascadeDelete: true)
                .Index(t => t.GiftCardId)
                .Index(t => t.UsedWithOrderId);
            
            CreateTable(
                "dbo.GiftCard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasedWithOrderItemId = c.Int(),
                        GiftCardTypeId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 4),
                        IsGiftCardActivated = c.Boolean(nullable: false),
                        GiftCardCouponCode = c.String(),
                        RecipientName = c.String(),
                        RecipientEmail = c.String(),
                        SenderName = c.String(),
                        SenderEmail = c.String(),
                        Message = c.String(),
                        IsRecipientNotified = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItem", t => t.PurchasedWithOrderItemId)
                .Index(t => t.PurchasedWithOrderItemId);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderItemGuid = c.Guid(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPriceInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        UnitPriceExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        PriceInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        PriceExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        DiscountAmountInclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        DiscountAmountExclTax = c.Decimal(nullable: false, precision: 18, scale: 4),
                        OriginalProductCost = c.Decimal(nullable: false, precision: 18, scale: 4),
                        AttributeDescription = c.String(),
                        AttributesXml = c.String(),
                        DownloadCount = c.Int(nullable: false),
                        IsDownloadActivated = c.Boolean(nullable: false),
                        LicenseDownloadId = c.Int(),
                        ItemWeight = c.Decimal(precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderNote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                        DisplayToCustomer = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        TrackingNumber = c.String(),
                        TotalWeight = c.Decimal(precision: 18, scale: 4),
                        ShippedDateUtc = c.DateTime(),
                        DeliveryDateUtc = c.DateTime(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.ShipmentItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentId = c.Int(nullable: false),
                        OrderItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shipment", t => t.ShipmentId, cascadeDelete: true)
                .Index(t => t.ShipmentId);
            
            CreateTable(
                "dbo.ShoppingCartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        ShoppingCartTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        AttributesXml = c.String(),
                        CustomerEnteredPrice = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Quantity = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ManufacturerTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        ViewPath = c.String(nullable: false, maxLength: 400),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        ViewPath = c.String(nullable: false, maxLength: 400),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        ViewPath = c.String(nullable: false, maxLength: 400),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenericAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        KeyGroup = c.String(nullable: false, maxLength: 400),
                        Key = c.String(nullable: false, maxLength: 400),
                        Value = c.String(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryDate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        Email = c.String(maxLength: 400),
                        Description = c.String(),
                        AdminComment = c.String(),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreMapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        EntityName = c.String(nullable: false, maxLength: 400),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        Url = c.String(nullable: false, maxLength: 400),
                        SslEnabled = c.Boolean(nullable: false),
                        SecureUrl = c.String(maxLength: 400),
                        Hosts = c.String(maxLength: 1000),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AclRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        EntityName = c.String(nullable: false, maxLength: 400),
                        CustomerRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRoleId, cascadeDelete: true)
                .Index(t => t.CustomerRoleId);
            
            CreateTable(
                "dbo.UrlRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        EntityName = c.String(nullable: false, maxLength: 400),
                        Slug = c.String(nullable: false, maxLength: 400),
                        IsActive = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Seconds = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        StopOnError = c.Boolean(nullable: false),
                        LastStartUtc = c.DateTime(),
                        LastEndUtc = c.DateTime(),
                        LastSuccessUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Affiliate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        CommentCount = c.Int(nullable: false),
                        Tags = c.String(),
                        StartDateUtc = c.DateTime(),
                        EndDateUtc = c.DateTime(),
                        MetaKeywords = c.String(maxLength: 400),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(maxLength: 400),
                        LimitedToStores = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.BlogComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CommentText = c.String(),
                        BlogPostId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPost", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LanguageCulture = c.String(nullable: false, maxLength: 20),
                        UniqueSeoCode = c.String(maxLength: 2),
                        FlagImageFileName = c.String(maxLength: 50),
                        Rtl = c.Boolean(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocaleStringResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        ResourceName = c.String(nullable: false, maxLength: 200),
                        ResourceValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.NewsComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentTitle = c.String(),
                        CommentText = c.String(),
                        NewsItemId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.NewsItemId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NewsItemId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Short = c.String(nullable: false),
                        Full = c.String(nullable: false),
                        Published = c.Boolean(nullable: false),
                        StartDateUtc = c.DateTime(),
                        EndDateUtc = c.DateTime(),
                        AllowComments = c.Boolean(nullable: false),
                        CommentCount = c.Int(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                        MetaKeywords = c.String(maxLength: 400),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(maxLength: 400),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.MeasureWeight",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SystemKeyword = c.String(nullable: false, maxLength: 100),
                        Ratio = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasureDimension",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SystemKeyword = c.String(nullable: false, maxLength: 100),
                        Ratio = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CurrencyCode = c.String(nullable: false, maxLength: 5),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 4),
                        DisplayLocale = c.String(maxLength: 50),
                        CustomFormatting = c.String(maxLength: 50),
                        LimitedToStores = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Forums_Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Forums_Forum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumGroupId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        NumTopics = c.Int(nullable: false),
                        NumPosts = c.Int(nullable: false),
                        LastTopicId = c.Int(nullable: false),
                        LastPostId = c.Int(nullable: false),
                        LastPostCustomerId = c.Int(nullable: false),
                        LastPostTime = c.DateTime(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forums_Group", t => t.ForumGroupId, cascadeDelete: true)
                .Index(t => t.ForumGroupId);
            
            CreateTable(
                "dbo.Forums_Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        IPAddress = c.String(maxLength: 100),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Forums_Topic", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Forums_Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        TopicTypeId = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 450),
                        NumPosts = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        LastPostId = c.Int(nullable: false),
                        LastPostCustomerId = c.Int(nullable: false),
                        LastPostTime = c.DateTime(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        UpdatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.Forums_Forum", t => t.ForumId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ForumId);
            
            CreateTable(
                "dbo.Forums_Subscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubscriptionGuid = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ForumId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Forums_PrivateMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        FromCustomerId = c.Int(nullable: false),
                        ToCustomerId = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 450),
                        Text = c.String(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsDeletedByAuthor = c.Boolean(nullable: false),
                        IsDeletedByRecipient = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.FromCustomerId)
                .ForeignKey("dbo.Customer", t => t.ToCustomerId)
                .Index(t => t.FromCustomerId)
                .Index(t => t.ToCustomerId);
            
            CreateTable(
                "dbo.ActivityLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityLogTypeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityLogType", t => t.ActivityLogTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.ActivityLogTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ActivityLogType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemKeyword = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Download",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DownloadGuid = c.Guid(nullable: false),
                        UseDownloadUrl = c.Boolean(nullable: false),
                        DownloadUrl = c.String(),
                        DownloadBinary = c.Binary(),
                        ContentType = c.String(),
                        Filename = c.String(),
                        Extension = c.String(),
                        IsNew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        DisplayName = c.String(maxLength: 255),
                        Host = c.String(nullable: false, maxLength: 255),
                        Port = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        EnableSsl = c.Boolean(nullable: false),
                        UseDefaultCredentials = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        BccEmailAddresses = c.String(maxLength: 200),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EmailAccountId = c.Int(nullable: false),
                        LimitedToStores = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsLetterSubscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsLetterSubscriptionGuid = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QueuedEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        From = c.String(nullable: false, maxLength: 500),
                        FromName = c.String(maxLength: 500),
                        To = c.String(nullable: false, maxLength: 500),
                        ToName = c.String(maxLength: 500),
                        CC = c.String(maxLength: 500),
                        Bcc = c.String(maxLength: 500),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        SentTries = c.Int(nullable: false),
                        SentOnUtc = c.DateTime(),
                        EmailAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailAccount", t => t.EmailAccountId, cascadeDelete: true)
                .Index(t => t.EmailAccountId);
            
            CreateTable(
                "dbo.CheckoutAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        TextPrompt = c.String(),
                        IsRequired = c.Boolean(nullable: false),
                        ShippableProductRequired = c.Boolean(nullable: false),
                        IsTaxExempt = c.Boolean(nullable: false),
                        TaxCategoryId = c.Int(nullable: false),
                        AttributeControlTypeId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckoutAttributeValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CheckoutAttributeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 400),
                        ColorSquaresRgb = c.String(maxLength: 100),
                        PriceAdjustment = c.Decimal(nullable: false, precision: 18, scale: 4),
                        WeightAdjustment = c.Decimal(nullable: false, precision: 18, scale: 4),
                        IsPreSelected = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckoutAttribute", t => t.CheckoutAttributeId, cascadeDelete: true)
                .Index(t => t.CheckoutAttributeId);
            
            CreateTable(
                "dbo.RecurringPaymentHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecurringPaymentId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecurringPayment", t => t.RecurringPaymentId, cascadeDelete: true)
                .Index(t => t.RecurringPaymentId);
            
            CreateTable(
                "dbo.RecurringPayment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CycleLength = c.Int(nullable: false),
                        CyclePeriodId = c.Int(nullable: false),
                        TotalCycles = c.Int(nullable: false),
                        StartDateUtc = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        InitialOrderId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.InitialOrderId)
                .Index(t => t.InitialOrderId);
            
            CreateTable(
                "dbo.Poll",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        SystemKeyword = c.String(),
                        Published = c.Boolean(nullable: false),
                        ShowOnHomePage = c.Boolean(nullable: false),
                        AllowGuestsToVote = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        StartDateUtc = c.DateTime(),
                        EndDateUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.PollAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        NumberOfVotes = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Poll", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.PollVotingRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollAnswerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PollAnswer", t => t.PollAnswerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PollAnswerId);
            
            CreateTable(
                "dbo.LocalizedProperty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        LocaleKeyGroup = c.String(nullable: false, maxLength: 400),
                        LocaleKey = c.String(nullable: false, maxLength: 400),
                        LocaleValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.RelatedProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId1 = c.Int(nullable: false),
                        ProductId2 = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CrossSellProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId1 = c.Int(nullable: false),
                        ProductId2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogLevelId = c.Int(nullable: false),
                        ShortMessage = c.String(nullable: false),
                        FullMessage = c.String(),
                        IpAddress = c.String(maxLength: 200),
                        CustomerId = c.Int(),
                        PageUrl = c.String(),
                        ReferrerUrl = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Value = c.String(nullable: false, maxLength: 2000),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemName = c.String(),
                        IncludeInSitemap = c.Boolean(nullable: false),
                        IsPasswordProtected = c.Boolean(nullable: false),
                        Password = c.String(),
                        Title = c.String(),
                        Body = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        MetaTitle = c.String(),
                        LimitedToStores = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingMethodRestrictions",
                c => new
                    {
                        ShippingMethod_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShippingMethod_Id, t.Country_Id })
                .ForeignKey("dbo.ShippingMethod", t => t.ShippingMethod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.ShippingMethod_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Address_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.PermissionRecord_Role_Mapping",
                c => new
                    {
                        PermissionRecord_Id = c.Int(nullable: false),
                        CustomerRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionRecord_Id, t.CustomerRole_Id })
                .ForeignKey("dbo.PermissionRecord", t => t.PermissionRecord_Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRole_Id, cascadeDelete: true)
                .Index(t => t.PermissionRecord_Id)
                .Index(t => t.CustomerRole_Id);
            
            CreateTable(
                "dbo.Customer_CustomerRole_Mapping",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        CustomerRole_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.CustomerRole_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.CustomerRole", t => t.CustomerRole_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.CustomerRole_Id);
            
            CreateTable(
                "dbo.Discount_AppliedToCategories",
                c => new
                    {
                        Discount_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discount_Id, t.Category_Id })
                .ForeignKey("dbo.Discount", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Discount_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Product_ProductTag_Mapping",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        ProductTag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.ProductTag_Id })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductTag", t => t.ProductTag_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.ProductTag_Id);
            
            CreateTable(
                "dbo.Discount_AppliedToProducts",
                c => new
                    {
                        Discount_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discount_Id, t.Product_Id })
                .ForeignKey("dbo.Discount", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Discount_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.LocalizedProperty", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.PollVotingRecord", "PollAnswerId", "dbo.PollAnswer");
            DropForeignKey("dbo.PollVotingRecord", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.PollAnswer", "PollId", "dbo.Poll");
            DropForeignKey("dbo.Poll", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.RecurringPaymentHistory", "RecurringPaymentId", "dbo.RecurringPayment");
            DropForeignKey("dbo.RecurringPayment", "InitialOrderId", "dbo.Order");
            DropForeignKey("dbo.CheckoutAttributeValue", "CheckoutAttributeId", "dbo.CheckoutAttribute");
            DropForeignKey("dbo.QueuedEmail", "EmailAccountId", "dbo.EmailAccount");
            DropForeignKey("dbo.ActivityLog", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ActivityLog", "ActivityLogTypeId", "dbo.ActivityLogType");
            DropForeignKey("dbo.Forums_PrivateMessage", "ToCustomerId", "dbo.Customer");
            DropForeignKey("dbo.Forums_PrivateMessage", "FromCustomerId", "dbo.Customer");
            DropForeignKey("dbo.Forums_Subscription", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Forums_Post", "TopicId", "dbo.Forums_Topic");
            DropForeignKey("dbo.Forums_Topic", "ForumId", "dbo.Forums_Forum");
            DropForeignKey("dbo.Forums_Topic", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Forums_Post", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Forums_Forum", "ForumGroupId", "dbo.Forums_Group");
            DropForeignKey("dbo.NewsComment", "NewsItemId", "dbo.News");
            DropForeignKey("dbo.News", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.NewsComment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.BlogPost", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.LocaleStringResource", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.BlogComment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.BlogComment", "BlogPostId", "dbo.BlogPost");
            DropForeignKey("dbo.Affiliate", "AddressId", "dbo.Address");
            DropForeignKey("dbo.AclRecord", "CustomerRoleId", "dbo.CustomerRole");
            DropForeignKey("dbo.StoreMapping", "StoreId", "dbo.Store");
            DropForeignKey("dbo.BackInStockSubscription", "ProductId", "dbo.Product");
            DropForeignKey("dbo.BackInStockSubscription", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ShoppingCartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ShoppingCartItem", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "ShippingAddress_Id", "dbo.Address");
            DropForeignKey("dbo.RewardPointsHistory", "UsedWithOrder_Id", "dbo.Order");
            DropForeignKey("dbo.Order", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.ShipmentItem", "ShipmentId", "dbo.Shipment");
            DropForeignKey("dbo.Shipment", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderNote", "OrderId", "dbo.Order");
            DropForeignKey("dbo.GiftCardUsageHistory", "UsedWithOrderId", "dbo.Order");
            DropForeignKey("dbo.GiftCardUsageHistory", "GiftCardId", "dbo.GiftCard");
            DropForeignKey("dbo.GiftCard", "PurchasedWithOrderItemId", "dbo.OrderItem");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.DiscountUsageHistory", "OrderId", "dbo.Order");
            DropForeignKey("dbo.DiscountUsageHistory", "DiscountId", "dbo.Discount");
            DropForeignKey("dbo.DiscountRequirement", "DiscountId", "dbo.Discount");
            DropForeignKey("dbo.Discount_AppliedToProducts", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Discount_AppliedToProducts", "Discount_Id", "dbo.Discount");
            DropForeignKey("dbo.TierPrice", "ProductId", "dbo.Product");
            DropForeignKey("dbo.TierPrice", "CustomerRoleId", "dbo.CustomerRole");
            DropForeignKey("dbo.ProductVariantAttributeValue", "ProductVariantAttributeId", "dbo.Product_ProductAttribute_Mapping");
            DropForeignKey("dbo.Product_ProductAttribute_Mapping", "ProductAttributeId", "dbo.ProductAttribute");
            DropForeignKey("dbo.Product_ProductAttribute_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductVariantAttributeCombination", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product_ProductTag_Mapping", "ProductTag_Id", "dbo.ProductTag");
            DropForeignKey("dbo.Product_ProductTag_Mapping", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product_SpecificationAttribute_Mapping", "SpecificationAttributeOptionId", "dbo.SpecificationAttributeOption");
            DropForeignKey("dbo.SpecificationAttributeOption", "SpecificationAttributeId", "dbo.SpecificationAttribute");
            DropForeignKey("dbo.Product_SpecificationAttribute_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductReviewHelpfulness", "ProductReviewId", "dbo.ProductReview");
            DropForeignKey("dbo.ProductReview", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductReview", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Product_Picture_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product_Picture_Mapping", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.Product_Manufacturer_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product_Manufacturer_Mapping", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Product_Category_Mapping", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product_Category_Mapping", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Discount_AppliedToCategories", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Discount_AppliedToCategories", "Discount_Id", "dbo.Discount");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Order", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.RewardPointsHistory", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ReturnRequest", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ExternalAuthenticationRecord", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer_CustomerRole_Mapping", "CustomerRole_Id", "dbo.CustomerRole");
            DropForeignKey("dbo.Customer_CustomerRole_Mapping", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "CustomerRole_Id", "dbo.CustomerRole");
            DropForeignKey("dbo.PermissionRecord_Role_Mapping", "PermissionRecord_Id", "dbo.PermissionRecord");
            DropForeignKey("dbo.Customer", "BillingAddress_Id", "dbo.Address");
            DropForeignKey("dbo.CustomerAddresses", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.CustomerAddresses", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Address", "StateProvinceId", "dbo.StateProvince");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropForeignKey("dbo.StateProvince", "CountryId", "dbo.Country");
            DropForeignKey("dbo.ShippingMethodRestrictions", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.ShippingMethodRestrictions", "ShippingMethod_Id", "dbo.ShippingMethod");
            DropIndex("dbo.Log", new[] { "CustomerId" });
            DropIndex("dbo.LocalizedProperty", new[] { "LanguageId" });
            DropIndex("dbo.PollVotingRecord", new[] { "PollAnswerId" });
            DropIndex("dbo.PollVotingRecord", new[] { "CustomerId" });
            DropIndex("dbo.PollAnswer", new[] { "PollId" });
            DropIndex("dbo.Poll", new[] { "LanguageId" });
            DropIndex("dbo.RecurringPaymentHistory", new[] { "RecurringPaymentId" });
            DropIndex("dbo.RecurringPayment", new[] { "InitialOrderId" });
            DropIndex("dbo.CheckoutAttributeValue", new[] { "CheckoutAttributeId" });
            DropIndex("dbo.QueuedEmail", new[] { "EmailAccountId" });
            DropIndex("dbo.ActivityLog", new[] { "CustomerId" });
            DropIndex("dbo.ActivityLog", new[] { "ActivityLogTypeId" });
            DropIndex("dbo.Forums_PrivateMessage", new[] { "ToCustomerId" });
            DropIndex("dbo.Forums_PrivateMessage", new[] { "FromCustomerId" });
            DropIndex("dbo.Forums_Subscription", new[] { "CustomerId" });
            DropIndex("dbo.Forums_Post", new[] { "TopicId" });
            DropIndex("dbo.Forums_Topic", new[] { "ForumId" });
            DropIndex("dbo.Forums_Topic", new[] { "CustomerId" });
            DropIndex("dbo.Forums_Post", new[] { "CustomerId" });
            DropIndex("dbo.Forums_Forum", new[] { "ForumGroupId" });
            DropIndex("dbo.NewsComment", new[] { "NewsItemId" });
            DropIndex("dbo.News", new[] { "LanguageId" });
            DropIndex("dbo.NewsComment", new[] { "CustomerId" });
            DropIndex("dbo.BlogPost", new[] { "LanguageId" });
            DropIndex("dbo.LocaleStringResource", new[] { "LanguageId" });
            DropIndex("dbo.BlogComment", new[] { "CustomerId" });
            DropIndex("dbo.BlogComment", new[] { "BlogPostId" });
            DropIndex("dbo.Affiliate", new[] { "AddressId" });
            DropIndex("dbo.AclRecord", new[] { "CustomerRoleId" });
            DropIndex("dbo.StoreMapping", new[] { "StoreId" });
            DropIndex("dbo.BackInStockSubscription", new[] { "ProductId" });
            DropIndex("dbo.BackInStockSubscription", new[] { "CustomerId" });
            DropIndex("dbo.ShoppingCartItem", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCartItem", new[] { "CustomerId" });
            DropIndex("dbo.Customer", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.RewardPointsHistory", new[] { "UsedWithOrder_Id" });
            DropIndex("dbo.Order", new[] { "ShippingAddressId" });
            DropIndex("dbo.ShipmentItem", new[] { "ShipmentId" });
            DropIndex("dbo.Shipment", new[] { "OrderId" });
            DropIndex("dbo.OrderNote", new[] { "OrderId" });
            DropIndex("dbo.GiftCardUsageHistory", new[] { "UsedWithOrderId" });
            DropIndex("dbo.GiftCardUsageHistory", new[] { "GiftCardId" });
            DropIndex("dbo.GiftCard", new[] { "PurchasedWithOrderItemId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropIndex("dbo.DiscountUsageHistory", new[] { "OrderId" });
            DropIndex("dbo.DiscountUsageHistory", new[] { "DiscountId" });
            DropIndex("dbo.DiscountRequirement", new[] { "DiscountId" });
            DropIndex("dbo.Discount_AppliedToProducts", new[] { "Product_Id" });
            DropIndex("dbo.Discount_AppliedToProducts", new[] { "Discount_Id" });
            DropIndex("dbo.TierPrice", new[] { "ProductId" });
            DropIndex("dbo.TierPrice", new[] { "CustomerRoleId" });
            DropIndex("dbo.ProductVariantAttributeValue", new[] { "ProductVariantAttributeId" });
            DropIndex("dbo.Product_ProductAttribute_Mapping", new[] { "ProductAttributeId" });
            DropIndex("dbo.Product_ProductAttribute_Mapping", new[] { "ProductId" });
            DropIndex("dbo.ProductVariantAttributeCombination", new[] { "ProductId" });
            DropIndex("dbo.Product_ProductTag_Mapping", new[] { "ProductTag_Id" });
            DropIndex("dbo.Product_ProductTag_Mapping", new[] { "Product_Id" });
            DropIndex("dbo.Product_SpecificationAttribute_Mapping", new[] { "SpecificationAttributeOptionId" });
            DropIndex("dbo.SpecificationAttributeOption", new[] { "SpecificationAttributeId" });
            DropIndex("dbo.Product_SpecificationAttribute_Mapping", new[] { "ProductId" });
            DropIndex("dbo.ProductReviewHelpfulness", new[] { "ProductReviewId" });
            DropIndex("dbo.ProductReview", new[] { "ProductId" });
            DropIndex("dbo.ProductReview", new[] { "CustomerId" });
            DropIndex("dbo.Product_Picture_Mapping", new[] { "ProductId" });
            DropIndex("dbo.Product_Picture_Mapping", new[] { "PictureId" });
            DropIndex("dbo.Product_Manufacturer_Mapping", new[] { "ProductId" });
            DropIndex("dbo.Product_Manufacturer_Mapping", new[] { "ManufacturerId" });
            DropIndex("dbo.Product_Category_Mapping", new[] { "ProductId" });
            DropIndex("dbo.Product_Category_Mapping", new[] { "CategoryId" });
            DropIndex("dbo.Discount_AppliedToCategories", new[] { "Category_Id" });
            DropIndex("dbo.Discount_AppliedToCategories", new[] { "Discount_Id" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.Order", new[] { "BillingAddressId" });
            DropIndex("dbo.RewardPointsHistory", new[] { "CustomerId" });
            DropIndex("dbo.ReturnRequest", new[] { "CustomerId" });
            DropIndex("dbo.ExternalAuthenticationRecord", new[] { "CustomerId" });
            DropIndex("dbo.Customer_CustomerRole_Mapping", new[] { "CustomerRole_Id" });
            DropIndex("dbo.Customer_CustomerRole_Mapping", new[] { "Customer_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "CustomerRole_Id" });
            DropIndex("dbo.PermissionRecord_Role_Mapping", new[] { "PermissionRecord_Id" });
            DropIndex("dbo.Customer", new[] { "BillingAddress_Id" });
            DropIndex("dbo.CustomerAddresses", new[] { "Address_Id" });
            DropIndex("dbo.CustomerAddresses", new[] { "Customer_Id" });
            DropIndex("dbo.Address", new[] { "StateProvinceId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropIndex("dbo.StateProvince", new[] { "CountryId" });
            DropIndex("dbo.ShippingMethodRestrictions", new[] { "Country_Id" });
            DropIndex("dbo.ShippingMethodRestrictions", new[] { "ShippingMethod_Id" });
            DropTable("dbo.Discount_AppliedToProducts");
            DropTable("dbo.Product_ProductTag_Mapping");
            DropTable("dbo.Discount_AppliedToCategories");
            DropTable("dbo.Customer_CustomerRole_Mapping");
            DropTable("dbo.PermissionRecord_Role_Mapping");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.ShippingMethodRestrictions");
            DropTable("dbo.Topic");
            DropTable("dbo.TaxCategory");
            DropTable("dbo.Setting");
            DropTable("dbo.Log");
            DropTable("dbo.CrossSellProduct");
            DropTable("dbo.RelatedProduct");
            DropTable("dbo.LocalizedProperty");
            DropTable("dbo.PollVotingRecord");
            DropTable("dbo.PollAnswer");
            DropTable("dbo.Poll");
            DropTable("dbo.RecurringPayment");
            DropTable("dbo.RecurringPaymentHistory");
            DropTable("dbo.CheckoutAttributeValue");
            DropTable("dbo.CheckoutAttribute");
            DropTable("dbo.QueuedEmail");
            DropTable("dbo.NewsLetterSubscription");
            DropTable("dbo.MessageTemplate");
            DropTable("dbo.EmailAccount");
            DropTable("dbo.Campaign");
            DropTable("dbo.Download");
            DropTable("dbo.ActivityLogType");
            DropTable("dbo.ActivityLog");
            DropTable("dbo.Forums_PrivateMessage");
            DropTable("dbo.Forums_Subscription");
            DropTable("dbo.Forums_Topic");
            DropTable("dbo.Forums_Post");
            DropTable("dbo.Forums_Forum");
            DropTable("dbo.Forums_Group");
            DropTable("dbo.Currency");
            DropTable("dbo.MeasureDimension");
            DropTable("dbo.MeasureWeight");
            DropTable("dbo.News");
            DropTable("dbo.NewsComment");
            DropTable("dbo.LocaleStringResource");
            DropTable("dbo.Language");
            DropTable("dbo.BlogComment");
            DropTable("dbo.BlogPost");
            DropTable("dbo.Affiliate");
            DropTable("dbo.ScheduleTask");
            DropTable("dbo.UrlRecord");
            DropTable("dbo.AclRecord");
            DropTable("dbo.Store");
            DropTable("dbo.StoreMapping");
            DropTable("dbo.Vendor");
            DropTable("dbo.DeliveryDate");
            DropTable("dbo.Warehouse");
            DropTable("dbo.GenericAttribute");
            DropTable("dbo.ProductTemplate");
            DropTable("dbo.CategoryTemplate");
            DropTable("dbo.ManufacturerTemplate");
            DropTable("dbo.ShoppingCartItem");
            DropTable("dbo.ShipmentItem");
            DropTable("dbo.Shipment");
            DropTable("dbo.OrderNote");
            DropTable("dbo.OrderItem");
            DropTable("dbo.GiftCard");
            DropTable("dbo.GiftCardUsageHistory");
            DropTable("dbo.DiscountRequirement");
            DropTable("dbo.TierPrice");
            DropTable("dbo.ProductVariantAttributeValue");
            DropTable("dbo.ProductAttribute");
            DropTable("dbo.Product_ProductAttribute_Mapping");
            DropTable("dbo.ProductVariantAttributeCombination");
            DropTable("dbo.ProductTag");
            DropTable("dbo.SpecificationAttribute");
            DropTable("dbo.SpecificationAttributeOption");
            DropTable("dbo.Product_SpecificationAttribute_Mapping");
            DropTable("dbo.ProductReviewHelpfulness");
            DropTable("dbo.ProductReview");
            DropTable("dbo.Picture");
            DropTable("dbo.Product_Picture_Mapping");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Product_Manufacturer_Mapping");
            DropTable("dbo.Product_Category_Mapping");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.Discount");
            DropTable("dbo.DiscountUsageHistory");
            DropTable("dbo.Order");
            DropTable("dbo.RewardPointsHistory");
            DropTable("dbo.ReturnRequest");
            DropTable("dbo.ExternalAuthenticationRecord");
            DropTable("dbo.PermissionRecord");
            DropTable("dbo.CustomerRole");
            DropTable("dbo.StateProvince");
            DropTable("dbo.ShippingMethod");
            DropTable("dbo.Country");
            DropTable("dbo.Address");
            DropTable("dbo.Customer");
            DropTable("dbo.BackInStockSubscription");
        }
    }
}
