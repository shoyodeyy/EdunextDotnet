-- Migration script to add Quantity column and remove IsAvailable column from MenuItems table
-- Run this script in your SQL Server database

-- Step 1: Add Quantity column with default value 0
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[MenuItems]') AND name = 'Quantity')
BEGIN
    ALTER TABLE [dbo].[MenuItems]
    ADD [Quantity] INT NOT NULL DEFAULT 0;
    
    PRINT 'Column Quantity added successfully';
END
ELSE
BEGIN
    PRINT 'Column Quantity already exists';
END

-- Step 2: Remove IsAvailable column (if it exists)
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[MenuItems]') AND name = 'IsAvailable')
BEGIN
    ALTER TABLE [dbo].[MenuItems]
    DROP COLUMN [IsAvailable];
    
    PRINT 'Column IsAvailable removed successfully';
END
ELSE
BEGIN
    PRINT 'Column IsAvailable does not exist';
END

-- Verify the changes
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'MenuItems'
ORDER BY ORDINAL_POSITION;

