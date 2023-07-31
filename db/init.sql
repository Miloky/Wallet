use Wallet;

SET @T := (select UTC_TIMESTAMP());
SET @UserId := 1;

insert into Accounts(Name, Balance, CreatedOn, ModifiedOn, CreatedBy, ModifiedBy) values('monobank', 500, @T, @T, @UserId, @UserId);
insert into Accounts(Name, Balance, CreatedOn, ModifiedOn, CreatedBy, ModifiedBy) values('privatbank', 700, @T, @T, @UserId, @UserId);