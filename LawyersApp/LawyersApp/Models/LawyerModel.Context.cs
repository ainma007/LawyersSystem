﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LawyersApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LawyersEntities : DbContext
    {
        public LawyersEntities()
            : base("name=LawyersEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Achievements_Table> Achievements_Table { get; set; }
        public DbSet<Advocacyactivities_Table> Advocacyactivities_Table { get; set; }
        public DbSet<Arbitration_Table> Arbitration_Table { get; set; }
        public DbSet<Area_Table> Area_Table { get; set; }
        public DbSet<AwarenessWorkshops_Table> AwarenessWorkshops_Table { get; set; }
        public DbSet<Beneficiaries_Table> Beneficiaries_Table { get; set; }
        public DbSet<Consulting_Table> Consulting_Table { get; set; }
        public DbSet<Courses_Table> Courses_Table { get; set; }
        public DbSet<Courts_Table> Courts_Table { get; set; }
        public DbSet<DiligenceType_Table> DiligenceType_Table { get; set; }
        public DbSet<FamilyForum_Table> FamilyForum_Table { get; set; }
        public DbSet<FamilyWatch_Table> FamilyWatch_Table { get; set; }
        public DbSet<Gender_Table> Gender_Table { get; set; }
        public DbSet<Governorate_Table> Governorate_Table { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<IssuesStatus_Table> IssuesStatus_Table { get; set; }
        public DbSet<IssuesType_Table> IssuesType_Table { get; set; }
        public DbSet<Lawyer_Table> Lawyer_Table { get; set; }
        public DbSet<Legal_Assistance_Table> Legal_Assistance_Table { get; set; }
        public DbSet<LegalIssues_Table> LegalIssues_Table { get; set; }
        public DbSet<Media_Table> Media_Table { get; set; }
        public DbSet<Mediation_Table> Mediation_Table { get; set; }
        public DbSet<MediaType_Table> MediaType_Table { get; set; }
        public DbSet<Order_Table> Order_Table { get; set; }
        public DbSet<Project_Table> Project_Table { get; set; }
        public DbSet<ProjectControl_Table> ProjectControl_Table { get; set; }
        public DbSet<SystemicIssues_Table> SystemicIssues_Table { get; set; }
        public DbSet<SystemicIssuesInProject_Table> SystemicIssuesInProject_Table { get; set; }
        public DbSet<TargetGroup_Table> TargetGroup_Table { get; set; }
        public DbSet<TypeOfCase_Table> TypeOfCase_Table { get; set; }
        public DbSet<UserLogHistory> UserLogHistory { get; set; }
        public DbSet<Users_Table> Users_Table { get; set; }
        public DbSet<Versions_Table> Versions_Table { get; set; }
    }
}
