-- Active: 1697040233025@@127.0.0.1@3306@Wallet

-- CREATE TABLE `TransactionCategory`(
--     Id INT NOT NULL AUTO_INCREMENT,
--     Name VARCHAR(255) NOT NULL,
--     ParentCategoryId INT,
--     PRIMARY KEY (ID),
--     FOREIGN KEY (ParentCategoryId) REFERENCES TransactionCategory(Id)  
-- );

delete from `TransactionCategory`;

insert into `TransactionCategory`(`Name`) values ('Food & Drinks');
SET @Id = LAST_INSERT_ID();

INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Groceries', @Id),
('Restaurant, fast-food', @Id),
('Bar, cafe', @Id);





insert into `TransactionCategory`(`Name`) values ('Shopping');
SET @Id = LAST_INSERT_ID();

INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Clothes & shoes', @Id),
('Jewels, accessories', @Id),
('Health and beauty', @Id),
('Kids', @Id),
('Home, garden', @Id),
('Pets, animals', @Id),
('Electronics, accessories', @Id),
('Gifts, joy', @Id),
('Stationery, tools', @Id),
('Free time', @Id),
('Drug-store, chemist', @Id);


insert into `TransactionCategory`(`Name`) values ('Housing');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Rent', @Id),
('Mortgage', @Id),
('Energy, utilities', @Id),
('Services', @Id),
('Maintenance, repairs', @Id),
('Property insurance', @Id);


insert into `TransactionCategory`(`Name`) values ('Transportation');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Public transport', @Id),
('Taxi', @Id),
('Long distance', @Id),
('Business trips', @Id);


insert into `TransactionCategory`(`Name`) values ('Vehicle');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Fuel', @Id),
('Parking', @Id),
('Vehicle maintenance', @Id),
('Rentals', @Id),
('Vehicle insurance', @Id),
('Leasing', @Id);


insert into `TransactionCategory`(`Name`) values ('Life & Entertainment');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Health care, doctor', @Id),
('Wellness, beauty', @Id),
('Active sport, fitness', @Id),
('Culture, sport events', @Id),
('Life events', @Id),
('Hobbies', @Id),
('Education, development', @Id),
('Books, audio, subscriptions,', @Id),
('TV, streaming', @Id),
('Holiday, trips, hotels', @Id),
('Charity, gifts', @Id),
('Alcohol, tobacco', @Id),
('Lottery, gambling', @Id);

insert into `TransactionCategory`(`Name`) values ('Communication, PC');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Phone, cell phone', @Id),
('Internet', @Id),
('Software, apps, games', @Id),
('Postal service', @Id);

insert into `TransactionCategory`(`Name`) values ('Financial expenses');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Taxes', @Id),
('Insurances', @Id),
('Loan, interests', @Id),
('Fines', @Id),
('Advisory', @Id),
('Charges, Fees', @Id),
('Child Support', @Id);



insert into `TransactionCategory`(`Name`) values ('Investments');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Realty', @Id),
('Vehicles, chattels', @Id),
('Financial investments', @Id),
('Savings', @Id),
('Collections', @Id);


insert into `TransactionCategory`(`Name`) values ('Income');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Wage, invoices', @Id),
('Interests, dividends', @Id),
('Sale', @Id),
('Rental income', @Id),
('Dues & grants', @Id),
('Lending, renting', @Id),
('Checks, coupons', @Id),
('Lottery, gambling', @Id),
('Refunds (tax, purchase)', @Id),
('Child support', @Id),
('Gifts', @Id);


insert into `TransactionCategory`(`Name`) values ('Other');
SET @Id = LAST_INSERT_ID();
INSERT INTO `TransactionCategory`(`Name`, `ParentCategoryId`) VALUES
('Missing', @Id);

show tables;