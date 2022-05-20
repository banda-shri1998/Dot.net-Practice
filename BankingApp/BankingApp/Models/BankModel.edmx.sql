
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2022 13:24:48
-- Generated from EDMX file: C:\Users\Shrinivas.banda\source\repos\BankingApp\BankingApp\Models\BankModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankProjectDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__BankEmplo__Branc__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankEmployee] DROP CONSTRAINT [FK__BankEmplo__Branc__398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__Customer__Branch__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [FK__Customer__Branch__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__Loan__AccountNo__4316F928]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Loan] DROP CONSTRAINT [FK__Loan__AccountNo__4316F928];
GO
IF OBJECT_ID(N'[dbo].[FK__Transacti__trans__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK__Transacti__trans__3F466844];
GO
IF OBJECT_ID(N'[dbo].[FK__Transacti__trans__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK__Transacti__trans__403A8C7D];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BankEmployee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankEmployee];
GO
IF OBJECT_ID(N'[dbo].[Branch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branch];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Loan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loan];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BankEmployees'
CREATE TABLE [dbo].[BankEmployees] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [EmpName] varchar(50)  NOT NULL,
    [GENDER] char(6)  NULL,
    [BranchOffice] int  NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [IFSC] int IDENTITY(1,1) NOT NULL,
    [BranchName] varchar(max)  NOT NULL,
    [BranchAddress] varchar(max)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [AccNo] int IDENTITY(1,1) NOT NULL,
    [CustName] varchar(50)  NOT NULL,
    [CustAddress] varchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [PhoneNo] bigint  NOT NULL,
    [GENDER] char(6)  NULL,
    [AccountType] varchar(50)  NOT NULL,
    [Balance] decimal(19,4)  NULL,
    [BranchIFSC] int  NULL
);
GO

-- Creating table 'Loans'
CREATE TABLE [dbo].[Loans] (
    [LoanID] int IDENTITY(1,1) NOT NULL,
    [LoanType] varchar(20)  NULL,
    [LoanAmt] int  NULL,
    [AccountNo] int  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [transID] int IDENTITY(1,1) NOT NULL,
    [TransTime] datetime  NULL,
    [TransType] varchar(50)  NULL,
    [transFrom_accno] int  NULL,
    [transTo_accNo] int  NULL,
    [transAmount] decimal(19,4)  NULL,
    [trans_remark] varchar(20)  NULL
);
GO

-- Creating table 'RoleMasters'
CREATE TABLE [dbo].[RoleMasters] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RollName] varchar(50)  NULL
);
GO

-- Creating table 'UserRolesMappings'
CREATE TABLE [dbo].[UserRolesMappings] (
    [ID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(50)  NULL,
    [UserPassword] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmpId] in table 'BankEmployees'
ALTER TABLE [dbo].[BankEmployees]
ADD CONSTRAINT [PK_BankEmployees]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- Creating primary key on [IFSC] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([IFSC] ASC);
GO

-- Creating primary key on [AccNo] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([AccNo] ASC);
GO

-- Creating primary key on [LoanID] in table 'Loans'
ALTER TABLE [dbo].[Loans]
ADD CONSTRAINT [PK_Loans]
    PRIMARY KEY CLUSTERED ([LoanID] ASC);
GO

-- Creating primary key on [transID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([transID] ASC);
GO

-- Creating primary key on [ID] in table 'RoleMasters'
ALTER TABLE [dbo].[RoleMasters]
ADD CONSTRAINT [PK_RoleMasters]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserRolesMappings'
ALTER TABLE [dbo].[UserRolesMappings]
ADD CONSTRAINT [PK_UserRolesMappings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BranchOffice] in table 'BankEmployees'
ALTER TABLE [dbo].[BankEmployees]
ADD CONSTRAINT [FK__BankEmplo__Branc__398D8EEE]
    FOREIGN KEY ([BranchOffice])
    REFERENCES [dbo].[Branches]
        ([IFSC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__BankEmplo__Branc__398D8EEE'
CREATE INDEX [IX_FK__BankEmplo__Branc__398D8EEE]
ON [dbo].[BankEmployees]
    ([BranchOffice]);
GO

-- Creating foreign key on [BranchIFSC] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK__Customer__Branch__44FF419A]
    FOREIGN KEY ([BranchIFSC])
    REFERENCES [dbo].[Branches]
        ([IFSC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Customer__Branch__44FF419A'
CREATE INDEX [IX_FK__Customer__Branch__44FF419A]
ON [dbo].[Customers]
    ([BranchIFSC]);
GO

-- Creating foreign key on [AccountNo] in table 'Loans'
ALTER TABLE [dbo].[Loans]
ADD CONSTRAINT [FK__Loan__AccountNo__4316F928]
    FOREIGN KEY ([AccountNo])
    REFERENCES [dbo].[Customers]
        ([AccNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Loan__AccountNo__4316F928'
CREATE INDEX [IX_FK__Loan__AccountNo__4316F928]
ON [dbo].[Loans]
    ([AccountNo]);
GO

-- Creating foreign key on [transFrom_accno] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK__Transacti__trans__3F466844]
    FOREIGN KEY ([transFrom_accno])
    REFERENCES [dbo].[Customers]
        ([AccNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Transacti__trans__3F466844'
CREATE INDEX [IX_FK__Transacti__trans__3F466844]
ON [dbo].[Transactions]
    ([transFrom_accno]);
GO

-- Creating foreign key on [transTo_accNo] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK__Transacti__trans__403A8C7D]
    FOREIGN KEY ([transTo_accNo])
    REFERENCES [dbo].[Customers]
        ([AccNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Transacti__trans__403A8C7D'
CREATE INDEX [IX_FK__Transacti__trans__403A8C7D]
ON [dbo].[Transactions]
    ([transTo_accNo]);
GO

-- Creating foreign key on [RoleID] in table 'UserRolesMappings'
ALTER TABLE [dbo].[UserRolesMappings]
ADD CONSTRAINT [FK__UserRoles__RoleI__3A81B327]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[RoleMasters]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRoles__RoleI__3A81B327'
CREATE INDEX [IX_FK__UserRoles__RoleI__3A81B327]
ON [dbo].[UserRolesMappings]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserRolesMappings'
ALTER TABLE [dbo].[UserRolesMappings]
ADD CONSTRAINT [FK__UserRoles__UserI__3B75D760]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRoles__UserI__3B75D760'
CREATE INDEX [IX_FK__UserRoles__UserI__3B75D760]
ON [dbo].[UserRolesMappings]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------