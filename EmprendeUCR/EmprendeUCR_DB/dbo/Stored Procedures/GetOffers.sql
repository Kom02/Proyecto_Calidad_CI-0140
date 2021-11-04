CREATE PROCEDURE GetOffers AS
SELECT U.Offer_ID, U.Code_ID, U.User_Email, U.Category_ID, U.Amount, O.Initial_Date
FROM UniqueOffers U, Offer O
WHERE U.Offer_ID = O.Offer_ID
ORDER BY Initial_Date DESC;