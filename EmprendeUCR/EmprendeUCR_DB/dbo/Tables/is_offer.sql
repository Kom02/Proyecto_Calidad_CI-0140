create table Is_Offer(
  Offer_Id int NOT NULL,
  Code_Id int NOT NULL,
  User_Email varchar(100) NOT NULL,
  Category_Id int NOT NULL,
  Amount int NOT NULL,
  PRIMARY KEY (Offer_Id, Code_Id, User_Email, Category_Id),
  Foreign key (Offer_Id) References Offer (Offer_ID) ON DELETE CASCADE,
  Foreign key (Code_Id, User_Email, Category_Id) References Product_Service (Code_Id, Entrepreneur_Email, Category_Id) ON DELETE NO ACTION

);