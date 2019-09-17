using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _374Cloud.Entities;

namespace _374Cloud.Data
{
    public partial class rst374_cloud12Context : DbContext
    {
        public rst374_cloud12Context()
        {
        }

        public rst374_cloud12Context(DbContextOptions<rst374_cloud12Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogRef> CatalogRef { get; set; }
        public virtual DbSet<CodeRelations> CodeRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.204\\sql2012;Database=rst374_cloud12;User Id=eznz;password=9seqxtf7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CatalogRef>(entity =>
            {
                entity.ToTable("catalog_ref");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cat)
                    .HasColumnName("cat")
                    .HasMaxLength(550);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.LayerLevel).HasColumnName("layer_level");
            });

            modelBuilder.Entity<CodeRelations>(entity =>
            {
                entity.ToTable("code_relations");

                entity.HasIndex(e => e.Cat)
                    .HasName("IDX_code_relations_cat");

                entity.HasIndex(e => e.Clearance)
                    .HasName("IDX_code_relations_clearance");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_code_relations_code");

                entity.HasIndex(e => e.Id)
                    .HasName("IDX_code_relations_id");

                entity.HasIndex(e => e.SCat)
                    .HasName("IDX_code_relations_scat");

                entity.HasIndex(e => e.SsCat)
                    .HasName("IDX_code_relations_sscat");

                entity.HasIndex(e => e.SupplierCode)
                    .HasName("IDX_code_relations_spl_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AllocatedStock).HasColumnName("allocated_stock");

                entity.Property(e => e.AverageCost)
                    .HasColumnName("average_cost")
                    .HasColumnType("money");

                entity.Property(e => e.AvoidPoint).HasColumnName("avoid_point");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BestBefore)
                    .HasColumnName("best_before")
                    .HasMaxLength(50);

                entity.Property(e => e.BomId).HasColumnName("bom_id");

                entity.Property(e => e.BoxedQty)
                    .HasColumnName("boxed_qty")
                    .HasMaxLength(50);

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(50);

                entity.Property(e => e.Cat)
                    .HasColumnName("cat")
                    .HasMaxLength(50);

                entity.Property(e => e.Clearance).HasColumnName("clearance");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.ComingSoon)
                    .HasColumnName("coming_soon")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CommissionRate).HasColumnName("commission_rate");

                entity.Property(e => e.CoreRange).HasColumnName("core_range");

                entity.Property(e => e.CostAccount).HasColumnName("cost_account");

                entity.Property(e => e.CostofsalesAccount)
                    .HasColumnName("costofsales_account")
                    .HasDefaultValueSql("((5111))");

                entity.Property(e => e.CountryOfOrigin)
                    .HasColumnName("country_of_origin")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateRange).HasColumnName("date_range");

                entity.Property(e => e.Disappeared).HasColumnName("disappeared");

                entity.Property(e => e.DoNotRounddown).HasColumnName("do_not_rounddown");

                entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("expire_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ForeignSupplierPrice)
                    .HasColumnName("foreign_supplier_price")
                    .HasColumnType("money");

                entity.Property(e => e.HasScale).HasColumnName("has_scale");

                entity.Property(e => e.Hidden).HasColumnName("hidden");

                entity.Property(e => e.Hot)
                    .HasColumnName("hot")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Inactive)
                    .HasColumnName("inactive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncomeAccount).HasColumnName("income_account");

                entity.Property(e => e.InnerPack).HasColumnName("inner_pack");

                entity.Property(e => e.InventoryAccount).HasColumnName("inventory_account");

                entity.Property(e => e.IsBarcodeprice).HasColumnName("is_barcodeprice");

                entity.Property(e => e.IsIdCheck).HasColumnName("is_id_check");

                entity.Property(e => e.IsMemberOnly).HasColumnName("is_member_only");

                entity.Property(e => e.IsService).HasColumnName("is_service");

                entity.Property(e => e.IsSpecial).HasColumnName("is_special");

                entity.Property(e => e.IsVoidDiscount).HasColumnName("is_void_discount");

                entity.Property(e => e.IsWebsiteItem).HasColumnName("is_website_item");

                entity.Property(e => e.LevelPrice0)
                    .HasColumnName("level_price0")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice1)
                    .HasColumnName("level_price1")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice2)
                    .HasColumnName("level_price2")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice3)
                    .HasColumnName("level_price3")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice4)
                    .HasColumnName("level_price4")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice5)
                    .HasColumnName("level_price5")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice6)
                    .HasColumnName("level_price6")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice7)
                    .HasColumnName("level_price7")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice8)
                    .HasColumnName("level_price8")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice9)
                    .HasColumnName("level_price9")
                    .HasColumnType("money");

                entity.Property(e => e.LevelRate1)
                    .HasColumnName("level_rate1")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.LevelRate2)
                    .HasColumnName("level_rate2")
                    .HasDefaultValueSql("((95))");

                entity.Property(e => e.LevelRate3)
                    .HasColumnName("level_rate3")
                    .HasDefaultValueSql("((90))");

                entity.Property(e => e.LevelRate4)
                    .HasColumnName("level_rate4")
                    .HasDefaultValueSql("((85))");

                entity.Property(e => e.LevelRate5)
                    .HasColumnName("level_rate5")
                    .HasDefaultValueSql("((80))");

                entity.Property(e => e.LevelRate6)
                    .HasColumnName("level_rate6")
                    .HasDefaultValueSql("((78))");

                entity.Property(e => e.LevelRate7)
                    .HasColumnName("level_rate7")
                    .HasDefaultValueSql("((75))");

                entity.Property(e => e.LevelRate8)
                    .HasColumnName("level_rate8")
                    .HasDefaultValueSql("((73))");

                entity.Property(e => e.LevelRate9)
                    .HasColumnName("level_rate9")
                    .HasDefaultValueSql("((70))");

                entity.Property(e => e.Line1Font)
                    .HasColumnName("line1_font")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.Line2Font)
                    .HasColumnName("line2_font")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.LowStock).HasColumnName("low_stock");

                entity.Property(e => e.ManualCostFrd)
                    .HasColumnName("manual_cost_frd")
                    .HasColumnType("money");

                entity.Property(e => e.ManualCostNzd)
                    .HasColumnName("manual_cost_nzd")
                    .HasColumnType("money");

                entity.Property(e => e.ManualExchangeRate)
                    .HasColumnName("manual_exchange_rate")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Moq)
                    .HasColumnName("moq")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasMaxLength(350);

                entity.Property(e => e.NewItem).HasColumnName("new_item");

                entity.Property(e => e.NewItemDate)
                    .HasColumnName("new_item_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoDiscount).HasColumnName("no_discount");

                entity.Property(e => e.NormalPrice).HasColumnName("normal_price");

                entity.Property(e => e.NzdFreight)
                    .HasColumnName("nzd_freight")
                    .HasColumnType("money");

                entity.Property(e => e.OuterPackBarcode)
                    .HasColumnName("outer_pack_barcode")
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode1)
                    .HasColumnName("package_barcode1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode2)
                    .HasColumnName("package_barcode2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode3)
                    .HasColumnName("package_barcode3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackagePrice1).HasColumnName("package_price1");

                entity.Property(e => e.PackagePrice2).HasColumnName("package_price2");

                entity.Property(e => e.PackagePrice3).HasColumnName("package_price3");

                entity.Property(e => e.PackageQty1).HasColumnName("package_qty1");

                entity.Property(e => e.PackageQty2).HasColumnName("package_qty2");

                entity.Property(e => e.PackageQty3).HasColumnName("package_qty3");

                entity.Property(e => e.PickDate).HasColumnName("pick_date");

                entity.Property(e => e.Popular)
                    .HasColumnName("popular")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Price1)
                    .HasColumnName("price1")
                    .HasColumnType("money");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasColumnType("money");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasColumnType("money");

                entity.Property(e => e.Price4)
                    .HasColumnName("price4")
                    .HasColumnType("money");

                entity.Property(e => e.Price5)
                    .HasColumnName("price5")
                    .HasColumnType("money");

                entity.Property(e => e.Price6)
                    .HasColumnName("price6")
                    .HasColumnType("money");

                entity.Property(e => e.Price7)
                    .HasColumnName("price7")
                    .HasColumnType("money");

                entity.Property(e => e.Price8)
                    .HasColumnName("price8")
                    .HasColumnType("money");

                entity.Property(e => e.Price9)
                    .HasColumnName("price9")
                    .HasColumnType("money");

                entity.Property(e => e.PriceSystem)
                    .HasColumnName("price_system")
                    .HasColumnType("money");

                entity.Property(e => e.PrintFormatCode).HasColumnName("print_format_code");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromoId)
                    .HasColumnName("promo_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Promotion)
                    .HasColumnName("promotion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QposQtyBreak).HasColumnName("qpos_qty_break");

                entity.Property(e => e.QtyBreak1)
                    .HasColumnName("qty_break1")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.QtyBreak2)
                    .HasColumnName("qty_break2")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.QtyBreak3)
                    .HasColumnName("qty_break3")
                    .HasDefaultValueSql("((20))");

                entity.Property(e => e.QtyBreak4)
                    .HasColumnName("qty_break4")
                    .HasDefaultValueSql("((50))");

                entity.Property(e => e.QtyBreak5).HasColumnName("qty_break5");

                entity.Property(e => e.QtyBreak6).HasColumnName("qty_break6");

                entity.Property(e => e.QtyBreak7).HasColumnName("qty_break7");

                entity.Property(e => e.QtyBreak8).HasColumnName("qty_break8");

                entity.Property(e => e.QtyBreak9).HasColumnName("qty_break9");

                entity.Property(e => e.QtyBreakDiscount1).HasColumnName("qty_break_discount1");

                entity.Property(e => e.QtyBreakDiscount2).HasColumnName("qty_break_discount2");

                entity.Property(e => e.QtyBreakDiscount3).HasColumnName("qty_break_discount3");

                entity.Property(e => e.QtyBreakDiscount4).HasColumnName("qty_break_discount4");

                entity.Property(e => e.QtyBreakDiscount5).HasColumnName("qty_break_discount5");

                entity.Property(e => e.QtyBreakDiscount6).HasColumnName("qty_break_discount6");

                entity.Property(e => e.QtyBreakDiscount7).HasColumnName("qty_break_discount7");

                entity.Property(e => e.QtyBreakDiscount8).HasColumnName("qty_break_discount8");

                entity.Property(e => e.QtyBreakDiscount9).HasColumnName("qty_break_discount9");

                entity.Property(e => e.QtyBreakPrice1)
                    .HasColumnName("qty_break_price1")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice10)
                    .HasColumnName("qty_break_price10")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice2)
                    .HasColumnName("qty_break_price2")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice3)
                    .HasColumnName("qty_break_price3")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice4)
                    .HasColumnName("qty_break_price4")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice5)
                    .HasColumnName("qty_break_price5")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice6)
                    .HasColumnName("qty_break_price6")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice7)
                    .HasColumnName("qty_break_price7")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice8)
                    .HasColumnName("qty_break_price8")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice9)
                    .HasColumnName("qty_break_price9")
                    .HasColumnType("money");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("((1.1))");

                entity.Property(e => e.RealStock).HasColumnName("real_stock");

                entity.Property(e => e.RedeemPoint).HasColumnName("redeem_point");

                entity.Property(e => e.RefCode)
                    .HasColumnName("ref_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rrp)
                    .HasColumnName("rrp")
                    .HasColumnType("money");

                entity.Property(e => e.SCat)
                    .HasColumnName("s_cat")
                    .HasMaxLength(50);

                entity.Property(e => e.ScaleDescriptionLine1)
                    .HasColumnName("scale_description_line1")
                    .HasMaxLength(50);

                entity.Property(e => e.ScaleDescriptionLine2)
                    .HasColumnName("scale_description_line2")
                    .HasMaxLength(50);

                entity.Property(e => e.SellBy)
                    .HasColumnName("sell_by")
                    .HasMaxLength(50);

                entity.Property(e => e.Skip).HasColumnName("skip");

                entity.Property(e => e.SkuCode)
                    .HasColumnName("sku_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialCost)
                    .HasColumnName("special_cost")
                    .HasColumnType("money");

                entity.Property(e => e.SpecialCostEndDate)
                    .HasColumnName("special_cost_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialCostStartDate)
                    .HasColumnName("special_cost_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnName("special_price")
                    .HasColumnType("money");

                entity.Property(e => e.SpecialPriceEndDate)
                    .HasColumnName("special_price_end_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpecialPriceStartDate)
                    .HasColumnName("special_price_start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsCat)
                    .HasColumnName("ss_cat")
                    .HasMaxLength(50);

                entity.Property(e => e.StockLocation)
                    .HasColumnName("stock_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPrice)
                    .HasColumnName("supplier_price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tareweight)
                    .HasColumnName("tareweight")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("tax_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("((0.15))");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UsedBy)
                    .HasColumnName("used_by")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}
