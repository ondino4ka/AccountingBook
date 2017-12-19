USE AccountingBookDB
ALTER TABLE Categories
ADD CONSTRAINT PidNotEqualId CHECK (Categories.pid != Categories.idCategory)

