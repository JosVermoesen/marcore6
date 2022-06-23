using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace marnet.api.Migrations
{
    public partial class InitAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KnownAs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookingFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gdpr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbQualifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Qualifier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Version = table.Column<double>(type: "float", nullable: true),
                    Lbc1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbc2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbc3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbc4 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbQualifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbValeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Valeur = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Lbc1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Lbc2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Lbl1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbl2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbl3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Lbl4 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbValeurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftCustomers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    E072 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G101 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G102 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G103 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G104 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G105 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    G106 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A10c = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A104 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    A105 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    A106 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    A107 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    A108 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    V149 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    A109 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V150 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Vs03 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V161 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    A161 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V151 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V111 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V254 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    V255 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V256 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A170 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Vs04 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Vs05 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Vs06 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Vs07 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V225 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V227 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V247 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    A10a = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Vs02 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V224 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    A123 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A124 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A121 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    A122 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V259 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V260 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E070 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E071 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V252 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A191 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    A192 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    A193 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    A194 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    A197 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    _510z = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A130 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V301 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    A102 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A100 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    A101 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V226 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    V243 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V302 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Vs01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A125 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    A127 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V002 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    V257 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V258 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V244 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V251 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A120 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V201 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V202 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V203 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V204 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V205 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V206 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V207 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V208 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V209 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V210 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V211 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V245 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V246 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V253 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Uxxx = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V262 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    V263 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftKboCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftKboCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftLedgerAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    V020 = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Dece022 = table.Column<decimal>(type: "money", nullable: true),
                    Dece023 = table.Column<decimal>(type: "money", nullable: true),
                    Dece024 = table.Column<decimal>(type: "money", nullable: true),
                    Dece025 = table.Column<decimal>(type: "money", nullable: true),
                    Dece026 = table.Column<decimal>(type: "money", nullable: true),
                    Dece027 = table.Column<decimal>(type: "money", nullable: true),
                    Dece028 = table.Column<decimal>(type: "money", nullable: true),
                    Dece029 = table.Column<decimal>(type: "money", nullable: true),
                    Dece030 = table.Column<decimal>(type: "money", nullable: true),
                    Dece031 = table.Column<decimal>(type: "money", nullable: true),
                    V021 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V032 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V216 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RvID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftLedgerAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftMailforms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartyCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftMailforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    V105 = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    V221 = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    V106 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V107 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V108 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V110 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V111 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V168 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V169 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V112 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V113 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V115 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V116 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    V117 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    V118 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    V114 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V119 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V120 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V121 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V122 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V123 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V109 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V103 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V104 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    V124 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V125 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V001 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    V002 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    V249 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E112 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E113 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E121 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E122 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E123 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dece112 = table.Column<decimal>(type: "money", nullable: true),
                    Dece113 = table.Column<decimal>(type: "money", nullable: true),
                    Dece121 = table.Column<decimal>(type: "money", nullable: true),
                    Dece122 = table.Column<decimal>(type: "money", nullable: true),
                    Dece123 = table.Column<decimal>(type: "money", nullable: true),
                    V261 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RvID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftSuppliers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    A102 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A100 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Vs01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A125 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    A10c = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A104 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    A105 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    A106 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    A107 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    A108 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    V149 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    A109 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V150 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Vs03 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    A10a = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Vs02 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V224 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    V163 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V016 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    V161 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    A161 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    A170 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    V259 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V260 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A400 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V015 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V151 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V111 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Vs04 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    V017 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V018 = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    V001 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    V002 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    V226 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V227 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V247 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V254 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Decv018 = table.Column<decimal>(type: "money", nullable: true),
                    V255 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V256 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V262 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftSuppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VsoftYearSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V071 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    V217 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bkjr = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftYearSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    LikerId = table.Column<int>(type: "int", nullable: false),
                    LikeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.LikerId, x.LikeeId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikeeId",
                        column: x => x.LikeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VsoftContracts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    A010 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Vs99 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Vs98 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    V164 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    V165 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Aw2 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    A325 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    A600 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Vs97 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    B010 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    B014 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V166 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V223 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Vs96 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    V167 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DecB010 = table.Column<decimal>(type: "money", nullable: true),
                    DecB014 = table.Column<decimal>(type: "money", nullable: true),
                    Dece069 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E069 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E070 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E071 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E072 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VsoftCustomerId = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VsoftContracts_VsoftCustomers_VsoftCustomerId",
                        column: x => x.VsoftCustomerId,
                        principalTable: "VsoftCustomers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VsoftCustomerInvoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    V035 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V066 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V036 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V037 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V038 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V249 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Decv249 = table.Column<decimal>(type: "money", nullable: true),
                    V039 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Vs03 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V040 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Decv040 = table.Column<decimal>(type: "money", nullable: true),
                    V041 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V245 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V246 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    A000 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    B010 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DecB010 = table.Column<decimal>(type: "money", nullable: true),
                    B014 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DecB014 = table.Column<decimal>(type: "money", nullable: true),
                    B090 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DecB090 = table.Column<decimal>(type: "money", nullable: true),
                    B094 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DecB094 = table.Column<decimal>(type: "money", nullable: true),
                    V065 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv065 = table.Column<decimal>(type: "money", nullable: true),
                    E069 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dece069 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E071 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    E072 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V055 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv055 = table.Column<decimal>(type: "money", nullable: true),
                    V056 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv056 = table.Column<decimal>(type: "money", nullable: true),
                    V057 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv057 = table.Column<decimal>(type: "money", nullable: true),
                    V058 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv058 = table.Column<decimal>(type: "money", nullable: true),
                    V059 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv059 = table.Column<decimal>(type: "money", nullable: true),
                    V060 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv060 = table.Column<decimal>(type: "money", nullable: true),
                    V061 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv061 = table.Column<decimal>(type: "money", nullable: true),
                    V062 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv062 = table.Column<decimal>(type: "money", nullable: true),
                    V063 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv063 = table.Column<decimal>(type: "money", nullable: true),
                    V064 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv064 = table.Column<decimal>(type: "money", nullable: true),
                    RvDm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BstndNaam37 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TypeZending37 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BstBlob37 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RvXmltb2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VsoftCustomerid = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftCustomerInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VsoftCustomerInvoices_VsoftCustomers_VsoftCustomerid",
                        column: x => x.VsoftCustomerid,
                        principalTable: "VsoftCustomers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VsoftLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V070 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    V034 = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    V066 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V033 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    V038 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V035 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V067 = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    V068 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V069 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    V041 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V249 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V248 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    V245 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V246 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dece068 = table.Column<decimal>(type: "money", nullable: true),
                    V102 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RvID = table.Column<int>(type: "int", nullable: true),
                    VsoftLedgerAccountId = table.Column<string>(type: "nvarchar(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VsoftLedgers_VsoftLedgerAccounts_VsoftLedgerAccountId",
                        column: x => x.VsoftLedgerAccountId,
                        principalTable: "VsoftLedgerAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VsoftSupplierInvoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    V035 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V066 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V036 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V037 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V038 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    V249 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Decv249 = table.Column<decimal>(type: "money", nullable: true),
                    V039 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Vs03 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    V040 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Decv040 = table.Column<decimal>(type: "money", nullable: true),
                    V041 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    V245 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    V246 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RvDm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BstndNaam37 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TypeZending37 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BstBlob37 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    V042 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V043 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V044 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V045 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V046 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V047 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V048 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V049 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V050 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V051 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V052 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V053 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    V054 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Decv042 = table.Column<decimal>(type: "money", nullable: true),
                    Decv043 = table.Column<decimal>(type: "money", nullable: true),
                    Decv044 = table.Column<decimal>(type: "money", nullable: true),
                    Decv045 = table.Column<decimal>(type: "money", nullable: true),
                    Decv046 = table.Column<decimal>(type: "money", nullable: true),
                    Decv047 = table.Column<decimal>(type: "money", nullable: true),
                    Decv048 = table.Column<decimal>(type: "money", nullable: true),
                    Decv049 = table.Column<decimal>(type: "money", nullable: true),
                    Decv050 = table.Column<decimal>(type: "money", nullable: true),
                    Decv051 = table.Column<decimal>(type: "money", nullable: true),
                    Decv052 = table.Column<decimal>(type: "money", nullable: true),
                    Decv053 = table.Column<decimal>(type: "money", nullable: true),
                    Decv054 = table.Column<decimal>(type: "money", nullable: true),
                    VsoftSupplierId = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftSupplierInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VsoftSupplierInvoices_VsoftSuppliers_VsoftSupplierId",
                        column: x => x.VsoftSupplierId,
                        principalTable: "VsoftSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VsoftTelebibContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mij = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    MemoTb2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    VsoftContractId = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VsoftTelebibContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VsoftTelebibContracts_VsoftContracts_VsoftContractId",
                        column: x => x.VsoftContractId,
                        principalTable: "VsoftContracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeeId",
                table: "Likes",
                column: "LikeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VsoftContracts_VsoftCustomerId",
                table: "VsoftContracts",
                column: "VsoftCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_VsoftCustomerInvoices_VsoftCustomerid",
                table: "VsoftCustomerInvoices",
                column: "VsoftCustomerid");

            migrationBuilder.CreateIndex(
                name: "IX_VsoftLedgers_VsoftLedgerAccountId",
                table: "VsoftLedgers",
                column: "VsoftLedgerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VsoftSupplierInvoices_VsoftSupplierId",
                table: "VsoftSupplierInvoices",
                column: "VsoftSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_VsoftTelebibContracts_VsoftContractId",
                table: "VsoftTelebibContracts",
                column: "VsoftContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TbQualifiers");

            migrationBuilder.DropTable(
                name: "TbValeurs");

            migrationBuilder.DropTable(
                name: "VsoftCustomerInvoices");

            migrationBuilder.DropTable(
                name: "VsoftKboCodes");

            migrationBuilder.DropTable(
                name: "VsoftLedgers");

            migrationBuilder.DropTable(
                name: "VsoftMailforms");

            migrationBuilder.DropTable(
                name: "VsoftProducts");

            migrationBuilder.DropTable(
                name: "VsoftSupplierInvoices");

            migrationBuilder.DropTable(
                name: "VsoftTelebibContracts");

            migrationBuilder.DropTable(
                name: "VsoftYearSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "VsoftLedgerAccounts");

            migrationBuilder.DropTable(
                name: "VsoftSuppliers");

            migrationBuilder.DropTable(
                name: "VsoftContracts");

            migrationBuilder.DropTable(
                name: "VsoftCustomers");
        }
    }
}
