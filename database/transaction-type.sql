CREATE TABLE `TransactionType` (
    Id INT NOT NULL,
    Description VARCHAR(255) NOT NULL,
    PRIMARY KEY (ID)
);

INSERT INTO `TransactionType`(`Id`, `Description`) VALUES
(1, 'Income'),
(2, 'Expense'),
(3, 'Transfer');