using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _374Cloud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalog_ref",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(nullable: false),
                    seq = table.Column<int>(nullable: true),
                    cat = table.Column<string>(maxLength: 550, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog_ref", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "code_relations",
                columns: table => new
                {
                    id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    code = table.Column<int>(nullable: false),
                    supplier = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    supplier_code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    supplier_price = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    average_cost = table.Column<decimal>(type: "money", nullable: false),
                    rate = table.Column<double>(nullable: false, defaultValueSql: "((1.1))"),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    name_cn = table.Column<string>(maxLength: 350, nullable: true),
                    brand = table.Column<string>(maxLength: 50, nullable: true),
                    cat = table.Column<string>(maxLength: 50, nullable: true),
                    s_cat = table.Column<string>(maxLength: 50, nullable: true),
                    ss_cat = table.Column<string>(maxLength: 50, nullable: true),
                    hot = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    skip = table.Column<bool>(nullable: false),
                    clearance = table.Column<bool>(nullable: false),
                    inventory_account = table.Column<int>(nullable: true),
                    cost_account = table.Column<int>(nullable: true),
                    income_account = table.Column<int>(nullable: true),
                    foreign_supplier_price = table.Column<decimal>(type: "money", nullable: true),
                    currency = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    exchange_rate = table.Column<double>(nullable: true),
                    nzd_freight = table.Column<decimal>(type: "money", nullable: false),
                    level_rate1 = table.Column<double>(nullable: false, defaultValueSql: "((100))"),
                    level_rate2 = table.Column<double>(nullable: false, defaultValueSql: "((95))"),
                    level_rate3 = table.Column<double>(nullable: false, defaultValueSql: "((90))"),
                    level_rate4 = table.Column<double>(nullable: false, defaultValueSql: "((85))"),
                    level_rate5 = table.Column<double>(nullable: false, defaultValueSql: "((80))"),
                    level_rate6 = table.Column<double>(nullable: false, defaultValueSql: "((78))"),
                    level_rate7 = table.Column<double>(nullable: true, defaultValueSql: "((75))"),
                    level_rate8 = table.Column<double>(nullable: true, defaultValueSql: "((73))"),
                    level_rate9 = table.Column<double>(nullable: true, defaultValueSql: "((70))"),
                    level_price0 = table.Column<decimal>(type: "money", nullable: false),
                    level_price1 = table.Column<decimal>(type: "money", nullable: false),
                    level_price2 = table.Column<decimal>(type: "money", nullable: false),
                    level_price3 = table.Column<decimal>(type: "money", nullable: false),
                    level_price4 = table.Column<decimal>(type: "money", nullable: false),
                    level_price5 = table.Column<decimal>(type: "money", nullable: false),
                    level_price6 = table.Column<decimal>(type: "money", nullable: false),
                    level_price7 = table.Column<decimal>(type: "money", nullable: false),
                    level_price8 = table.Column<decimal>(type: "money", nullable: false),
                    level_price9 = table.Column<decimal>(type: "money", nullable: false),
                    qty_break1 = table.Column<int>(nullable: false, defaultValueSql: "((5))"),
                    qty_break2 = table.Column<int>(nullable: true, defaultValueSql: "((10))"),
                    qty_break3 = table.Column<int>(nullable: true, defaultValueSql: "((20))"),
                    qty_break4 = table.Column<int>(nullable: true, defaultValueSql: "((50))"),
                    qty_break5 = table.Column<int>(nullable: true),
                    qty_break6 = table.Column<int>(nullable: true),
                    qty_break7 = table.Column<int>(nullable: true),
                    qty_break8 = table.Column<int>(nullable: true),
                    qty_break9 = table.Column<int>(nullable: true),
                    qty_break_discount1 = table.Column<double>(nullable: false),
                    qty_break_discount2 = table.Column<double>(nullable: true),
                    qty_break_discount3 = table.Column<double>(nullable: true),
                    qty_break_discount4 = table.Column<double>(nullable: true),
                    qty_break_discount5 = table.Column<double>(nullable: true),
                    qty_break_discount6 = table.Column<double>(nullable: true),
                    qty_break_discount7 = table.Column<double>(nullable: true),
                    qty_break_discount8 = table.Column<double>(nullable: true),
                    qty_break_discount9 = table.Column<double>(nullable: true),
                    qty_break_price1 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price2 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price3 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price4 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price5 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price6 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price7 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price8 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price9 = table.Column<decimal>(type: "money", nullable: true),
                    qty_break_price10 = table.Column<decimal>(type: "money", nullable: true),
                    manual_cost_frd = table.Column<decimal>(type: "money", nullable: false),
                    manual_exchange_rate = table.Column<double>(nullable: false, defaultValueSql: "((1))"),
                    manual_cost_nzd = table.Column<decimal>(type: "money", nullable: false),
                    allocated_stock = table.Column<int>(nullable: false),
                    is_service = table.Column<bool>(nullable: false),
                    rrp = table.Column<decimal>(type: "money", nullable: false),
                    promotion = table.Column<byte>(nullable: true, defaultValueSql: "((0))"),
                    coming_soon = table.Column<byte>(nullable: true, defaultValueSql: "((0))"),
                    weight = table.Column<double>(nullable: true, defaultValueSql: "((0))"),
                    inactive = table.Column<byte>(nullable: true, defaultValueSql: "((0))"),
                    stock_location = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    popular = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    real_stock = table.Column<bool>(nullable: false),
                    disappeared = table.Column<int>(nullable: false),
                    price1 = table.Column<decimal>(type: "money", nullable: false),
                    price2 = table.Column<decimal>(type: "money", nullable: false),
                    price3 = table.Column<decimal>(type: "money", nullable: false),
                    price4 = table.Column<decimal>(type: "money", nullable: false),
                    price5 = table.Column<decimal>(type: "money", nullable: false),
                    price6 = table.Column<decimal>(type: "money", nullable: false),
                    price7 = table.Column<decimal>(type: "money", nullable: false),
                    price8 = table.Column<decimal>(type: "money", nullable: false),
                    price9 = table.Column<decimal>(type: "money", nullable: false),
                    price_system = table.Column<decimal>(type: "money", nullable: false),
                    barcode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    expire_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ref_code = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    low_stock = table.Column<int>(nullable: false),
                    package_barcode1 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    package_qty1 = table.Column<int>(nullable: true),
                    package_price1 = table.Column<double>(nullable: true),
                    package_barcode2 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    package_qty2 = table.Column<int>(nullable: true),
                    package_price2 = table.Column<double>(nullable: true),
                    package_barcode3 = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    package_qty3 = table.Column<int>(nullable: true),
                    package_price3 = table.Column<double>(nullable: true),
                    normal_price = table.Column<double>(nullable: true),
                    special_price = table.Column<decimal>(type: "money", nullable: true),
                    special_price_start_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    special_price_end_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    sku_code = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    costofsales_account = table.Column<int>(nullable: false, defaultValueSql: "((5111))"),
                    qpos_qty_break = table.Column<int>(nullable: false),
                    promo_id = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    has_scale = table.Column<bool>(nullable: false),
                    new_item = table.Column<bool>(nullable: false),
                    new_item_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_special = table.Column<bool>(nullable: false),
                    is_member_only = table.Column<bool>(nullable: false),
                    date_range = table.Column<bool>(nullable: false),
                    pick_date = table.Column<bool>(nullable: false),
                    avoid_point = table.Column<bool>(nullable: false),
                    redeem_point = table.Column<int>(nullable: false),
                    moq = table.Column<int>(nullable: true, defaultValueSql: "((1))"),
                    boxed_qty = table.Column<string>(maxLength: 50, nullable: true),
                    inner_pack = table.Column<int>(nullable: false),
                    hidden = table.Column<bool>(nullable: false),
                    commission_rate = table.Column<double>(nullable: false),
                    is_void_discount = table.Column<bool>(nullable: false),
                    is_barcodeprice = table.Column<bool>(nullable: false),
                    is_id_check = table.Column<bool>(nullable: false),
                    no_discount = table.Column<bool>(nullable: false),
                    tax_rate = table.Column<double>(nullable: false, defaultValueSql: "((0.15))"),
                    tax_code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    bom_id = table.Column<int>(nullable: true),
                    unit = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    best_before = table.Column<string>(maxLength: 50, nullable: true),
                    used_by = table.Column<string>(maxLength: 50, nullable: true),
                    sell_by = table.Column<string>(maxLength: 50, nullable: true),
                    product_code = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    tareweight = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    scale_description_line1 = table.Column<string>(maxLength: 50, nullable: true),
                    scale_description_line2 = table.Column<string>(maxLength: 50, nullable: true),
                    line1_font = table.Column<int>(nullable: false, defaultValueSql: "((9))"),
                    line2_font = table.Column<int>(nullable: false, defaultValueSql: "((9))"),
                    print_format_code = table.Column<int>(nullable: true),
                    is_website_item = table.Column<bool>(nullable: false),
                    special_cost = table.Column<decimal>(type: "money", nullable: true),
                    special_cost_start_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    special_cost_end_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    do_not_rounddown = table.Column<bool>(nullable: false),
                    outer_pack_barcode = table.Column<string>(unicode: false, maxLength: 99, nullable: true),
                    country_of_origin = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    core_range = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_code_relations", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_cat",
                table: "code_relations",
                column: "cat");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_clearance",
                table: "code_relations",
                column: "clearance");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_code",
                table: "code_relations",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_id",
                table: "code_relations",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_scat",
                table: "code_relations",
                column: "s_cat");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_sscat",
                table: "code_relations",
                column: "ss_cat");

            migrationBuilder.CreateIndex(
                name: "IDX_code_relations_spl_code",
                table: "code_relations",
                column: "supplier_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalog_ref");

            migrationBuilder.DropTable(
                name: "code_relations");
        }
    }
}
