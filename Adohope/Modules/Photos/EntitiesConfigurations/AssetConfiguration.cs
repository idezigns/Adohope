using Adohope.Modules.Photos.Contexts;
using Adohope.Modules.Photos.Models;
using Adohope.Modules.Photos.Repos;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.EntitiesConfigurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public static string TableName;

        public string ConnectionString { get; }

        public AssetConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
            TableName = PredictTableName();
        }

        protected string PredictTableName()
        {
            //======================================================================================
            // Check update number first, iOS 14 and later changed the table ZGENERICASSET to ZASSET
            //======================================================================================

            //try
            //{
            //    //var productVersion = (Backup as Backup).Info()?.ProductVersion;
            //    var updateNumber = ProductVersion.Major;

            //    return (updateNumber > 14)
            //        ? "ZASSET"
            //        : "ZGENERICASSET";
            //}
            //catch (FileNotFoundException)
            //{
            //    return "ZASSET";
            //}

            //======================================================================================
            // Check photos database directly by quering the table name
            //======================================================================================

            var assetTableNames = new string[] { "ZASSET", "ZGENERICASSET" };

            string[] tablesLookupResult = SQLiteSchemaCheckerUtils.WhichTableExists(ConnectionString, assetTableNames);

            if (tablesLookupResult.Length == 0)
            {
                var tablesNames = string.Join(" - ", tablesLookupResult);
                throw new NotSupportedException($"Unknown asset table name, table name is not one of those tables names [{tablesNames}]");
            }

            return tablesLookupResult[0];
        }

        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable(TableName);

            // ID
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .HasColumnName("Z_PK");

            // Kind
            builder.Property(c => c.Kind)
                .HasConversion<long>()
                .HasColumnName("ZKIND");

            // KindSubType
            builder.Property(c => c.KindSubType)
                .HasConversion<long>()
                .HasColumnName("ZKINDSUBTYPE");

            // Favorite
            builder.Property(c => c.Favorite)
                .HasConversion<bool>()
                .HasColumnName("ZFAVORITE");

            // Hidden
            builder.Property(c => c.Hidden)
                .HasConversion<bool>()
                .HasColumnName("ZHIDDEN");

            // RecentlyDeleted
            builder.Property(c => c.RecentlyDeleted)
                .HasConversion<bool>()
                .HasColumnName("ZTRASHEDSTATE");

            // Directory
            builder.Property(c => c.Directory)
                .HasColumnName("ZDIRECTORY");

            // FileName
            builder.Property(c => c.FileName)
                .HasColumnName("ZFILENAME");

            // RelativePath
            builder.Ignore(c => c.RelativePath);
            //builder.Property(c => c.RelativePath)
            //    .HasComputedColumnSql("('Media/' || ZDIRECTORY || '/' || ZFILENAME)");

            // MBFile
            builder.Ignore(c => c.MBFile);
        }
    }
}
