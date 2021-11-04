CREATE PROCEDURE get_unique_offers AS
SELECT Offer_ID, Code_ID, User_Email, Category_ID, Amount
  FROM (
                SELECT  Offer_ID, 
                        Code_ID, 
                        User_Email, 
                        Category_ID,
						Amount,
                        ROW_NUMBER() OVER(PARTITION BY Offer_ID ORDER BY Offer_ID DESC) rn
                    FROM Is_Offer
              ) a
WHERE rn = 1;