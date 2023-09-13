using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace VCA.Migrations
{
    /// <inheritdoc />
    public partial class vca_v24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "components",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    comp_name = table.Column<string>(type: "longtext", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_components", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    comp_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    address_line1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    address_line2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    pin_code = table.Column<string>(type: "longtext", nullable: false),
                    telephone = table.Column<string>(type: "longtext", nullable: false),
                    authorized_person_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    gst_number = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "segments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    seg_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segments", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    manu_name = table.Column<string>(type: "longtext", nullable: false),
                    seg_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.id);
                    table.ForeignKey(
                        name: "FK_manufacturers_segments_seg_id",
                        column: x => x.seg_id,
                        principalTable: "segments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    seg_id = table.Column<int>(type: "int", nullable: false),
                    manu_id = table.Column<int>(type: "int", nullable: true),
                    mod_name = table.Column<string>(type: "longtext", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    safety_rating = table.Column<int>(type: "int", nullable: false),
                    image_path = table.Column<string>(type: "longtext", nullable: false),
                    min_qty = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.id);
                    table.ForeignKey(
                        name: "FK_models_manufacturers_manu_id",
                        column: x => x.manu_id,
                        principalTable: "manufacturers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_models_segments_seg_id",
                        column: x => x.seg_id,
                        principalTable: "segments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alternate_components",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    delta_price = table.Column<double>(type: "double", nullable: false),
                    mod_id = table.Column<int>(type: "int", nullable: true),
                    comp_id = table.Column<int>(type: "int", nullable: false),
                    alt_comp_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternate_components", x => x.id);
                    table.ForeignKey(
                        name: "FK_alternate_components_components_alt_comp_id",
                        column: x => x.alt_comp_id,
                        principalTable: "components",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_alternate_components_components_comp_id",
                        column: x => x.comp_id,
                        principalTable: "components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alternate_components_models_mod_id",
                        column: x => x.mod_id,
                        principalTable: "models",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    comp_type = table.Column<int>(type: "int", nullable: false),
                    is_configurable = table.Column<int>(type: "int", nullable: false),
                    mod_id = table.Column<int>(type: "int", nullable: false),
                    comp_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_components_comp_id",
                        column: x => x.comp_id,
                        principalTable: "components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicles_models_mod_id",
                        column: x => x.mod_id,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    mod_id = table.Column<int>(type: "int", nullable: false),
                    alt_comp_id = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "double", nullable: false),
                    auth_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_alternate_components_alt_comp_id",
                        column: x => x.alt_comp_id,
                        principalTable: "alternate_components",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_invoices_models_mod_id",
                        column: x => x.mod_id,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoices_registration_auth_id",
                        column: x => x.auth_id,
                        principalTable: "registration",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_components_alt_comp_id",
                table: "alternate_components",
                column: "alt_comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_components_comp_id",
                table: "alternate_components",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_components_mod_id",
                table: "alternate_components",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_alt_comp_id",
                table: "invoices",
                column: "alt_comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_auth_id",
                table: "invoices",
                column: "auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_mod_id",
                table: "invoices",
                column: "mod_id");

            migrationBuilder.CreateIndex(
                name: "IX_manufacturers_seg_id",
                table: "manufacturers",
                column: "seg_id");

            migrationBuilder.CreateIndex(
                name: "IX_models_manu_id",
                table: "models",
                column: "manu_id");

            migrationBuilder.CreateIndex(
                name: "IX_models_seg_id",
                table: "models",
                column: "seg_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_comp_id",
                table: "vehicles",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_mod_id",
                table: "vehicles",
                column: "mod_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "alternate_components");

            migrationBuilder.DropTable(
                name: "registration");

            migrationBuilder.DropTable(
                name: "components");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "segments");
        }
    }
}
