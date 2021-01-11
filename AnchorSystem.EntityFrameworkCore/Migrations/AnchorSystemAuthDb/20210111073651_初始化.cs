using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnchorSystem.EntityFrameworkCore.Migrations.AnchorSystemAuthDb
{
    public partial class 初始化 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Online = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    WhiteIps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastLoginIp = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    LastEditPasswordTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ActiveTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    table.PrimaryKey("PK_AdminUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpWhitelist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastOperator = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastOperatingTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsUsing = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpWhitelist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PerCodeId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingObject = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    OperatingTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MarkDownText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorType = table.Column<int>(type: "int", nullable: false),
                    OperatorDetailsType = table.Column<int>(type: "int", nullable: false),
                    OperatorIp = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminRoleClaims",
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
                    table.PrimaryKey("PK_AdminRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminRoleClaims_AdminRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AdminRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUserClaims",
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
                    table.PrimaryKey("PK_AdminUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminUserClaims_AdminUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AdminUserLogins_AdminUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AdminRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminUserRoles_AdminUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AdminUserTokens_AdminUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IpArea = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    LoginUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LoginLogType = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginLogs_AdminUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerCodeId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    PerLevel = table.Column<int>(type: "int", nullable: false),
                    PerLimit = table.Column<int>(type: "int", nullable: false),
                    PerCodeType = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRole_Name",
                table: "AdminRole",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AdminRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRoleClaims_RoleId",
                table: "AdminRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AdminUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AdminUser",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserClaims_UserId",
                table: "AdminUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserLogins_UserId",
                table: "AdminUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminUserRoles_RoleId",
                table: "AdminUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IpWhitelist_IpAddress",
                table: "IpWhitelist",
                column: "IpAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogs_TenantId_LoginTime",
                table: "LoginLogs",
                columns: new[] { "TenantId", "LoginTime" });

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogs_UserId",
                table: "LoginLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Name",
                table: "Menu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecord_OperatingTime",
                table: "OperationRecord",
                column: "OperatingTime");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_MenuId",
                table: "Permission",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRoleClaims");

            migrationBuilder.DropTable(
                name: "AdminUserClaims");

            migrationBuilder.DropTable(
                name: "AdminUserLogins");

            migrationBuilder.DropTable(
                name: "AdminUserRoles");

            migrationBuilder.DropTable(
                name: "AdminUserTokens");

            migrationBuilder.DropTable(
                name: "IpWhitelist");

            migrationBuilder.DropTable(
                name: "LoginLogs");

            migrationBuilder.DropTable(
                name: "OperationRecord");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "AdminRole");

            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
