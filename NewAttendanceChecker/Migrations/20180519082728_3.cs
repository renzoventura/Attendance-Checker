using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NewAttendanceChecker.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Sessions_SessionID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Students_StudentID",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "AttendanceList");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StudentID",
                table: "AttendanceList",
                newName: "IX_AttendanceList_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_SessionID",
                table: "AttendanceList",
                newName: "IX_AttendanceList_SessionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceList",
                table: "AttendanceList",
                column: "AttendanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceList_Sessions_SessionID",
                table: "AttendanceList",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceList_Students_StudentID",
                table: "AttendanceList",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceList_Sessions_SessionID",
                table: "AttendanceList");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceList_Students_StudentID",
                table: "AttendanceList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceList",
                table: "AttendanceList");

            migrationBuilder.RenameTable(
                name: "AttendanceList",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceList_StudentID",
                table: "Attendance",
                newName: "IX_Attendance_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceList_SessionID",
                table: "Attendance",
                newName: "IX_Attendance_SessionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Sessions_SessionID",
                table: "Attendance",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Students_StudentID",
                table: "Attendance",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
