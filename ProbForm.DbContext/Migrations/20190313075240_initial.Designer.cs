﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProbForm.AppContext;

namespace ProbForm.DBContext.Migrations
{
    [DbContext(typeof(ProbFormDBContext))]
    [Migration("20190313075240_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("ProbForm.Models.Match", b =>
                {
                    b.Property<int>("Day");

                    b.Property<string>("HomeTeamId")
                        .HasMaxLength(50);

                    b.Property<string>("AwayTeamId")
                        .HasMaxLength(50);

                    b.Property<string>("AwayModule");

                    b.Property<string>("HomeModule");

                    b.Property<DateTime>("MatchTime");

                    b.HasKey("Day", "HomeTeamId", "AwayTeamId");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("ProbForm.Models.Player", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("TeamId")
                        .HasMaxLength(50);

                    b.Property<string>("Number");

                    b.HasKey("Name", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ProbForm.Models.Team", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Mister");

                    b.HasKey("Name");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ProbForm.Models.TeamPlayer", b =>
                {
                    b.Property<int>("MatchDay");

                    b.Property<string>("MatchHomeTeamId")
                        .HasMaxLength(50);

                    b.Property<string>("MatchAwayTeamId")
                        .HasMaxLength(50);

                    b.Property<string>("PlayerNameId")
                        .HasMaxLength(50);

                    b.Property<string>("PlayerTeamId")
                        .HasMaxLength(50);

                    b.Property<string>("Info");

                    b.Property<int>("Order");

                    b.Property<int>("Status");

                    b.Property<string>("TeamName");

                    b.HasKey("MatchDay", "MatchHomeTeamId", "MatchAwayTeamId", "PlayerNameId", "PlayerTeamId");

                    b.HasIndex("TeamName");

                    b.HasIndex("PlayerNameId", "PlayerTeamId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("ProbForm.Models.Match", b =>
                {
                    b.HasOne("ProbForm.Models.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProbForm.Models.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProbForm.Models.Player", b =>
                {
                    b.HasOne("ProbForm.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProbForm.Models.TeamPlayer", b =>
                {
                    b.HasOne("ProbForm.Models.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamName");

                    b.HasOne("ProbForm.Models.Player", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerNameId", "PlayerTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProbForm.Models.Match", "Match")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("MatchDay", "MatchHomeTeamId", "MatchAwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}