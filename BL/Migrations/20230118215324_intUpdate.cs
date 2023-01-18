using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class intUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentState",
                table: "TbSupplierProduct",
                type: "int",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValueSql: "((1))");

          

          

          

            migrationBuilder.AlterColumn<int>(
                name: "CurrentState",
                table: "TbPoliciesAndPrivacy",
                type: "int",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(string),
                oldType: "nchar(8)",
                oldFixedLength: true,
                oldMaxLength: 8,
                oldNullable: true,
                oldDefaultValueSql: "((1))");

          

           

           

           

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentState",
                table: "TbSupplierProduct",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((1))");

          

          

            migrationBuilder.AlterColumn<string>(
                name: "CurrentState",
                table: "TbPoliciesAndPrivacy",
                type: "nchar(8)",
                fixedLength: true,
                maxLength: 8,
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((1))");

          

          

          
          
        }
    }
}
