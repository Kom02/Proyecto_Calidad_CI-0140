CREATE VIEW Product_Shopping_Cart AS
select p.Code_ID,p.Entrepreneur_Email,p.Category_ID,p.Product_Name,p.Product_Description,p.Price
from Shopping_Cart sc JOIN Shopping_Cart_Has sh on sc.Email = sh.Email 
Join Product_Service ps on sh.Code_ID = ps.Code_ID and sh.Category_ID = ps.Category_ID and sh.Entrepreneur_Email = ps.Entrepreneur_Email
Join Product p on p.Code_ID = ps.Code_ID and p.Category_ID = ps.Category_ID and p.Entrepreneur_Email =  ps.Entrepreneur_Email