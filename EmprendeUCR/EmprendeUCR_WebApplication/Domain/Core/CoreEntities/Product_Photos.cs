using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * Story ID: PIIB12021-131
 * Worked by: Dario Matamoros
 *            Daniel Mayorga
 * Acceptance Criteria:
 *  The user interface display the option to add new photos. 
 *  The application display input boxes that guides the user to include photos to the products:
 *  Add a new photo
 *  The user can save succesfully a photo
 *  The photo is reflected on the database.
 *  The photo is succesfully linked to the product.
 * 
 * This story needs to be done so we can complete the story PIIB12021-4 Create a product.
 * The entreprenur needs to able to add a maximum of 6 images, where the first image added is the 
 * main image for that product. This needs to be displayed when adding a product and at the shopping cart.
 */

namespace EmprendeUCR_WebApplication.Domain.Core.CoreEntities
{
    public class Product_Photos
    {
        public int Product_Photos_ID { get; set; }
        public int Code_ID { get; set; }
        public string Entrepreneur_Email { get; set; }
        public int Category_ID { get; set; }
        public byte[] Photos { get; set; }

        //FK
        public Product product;

    }
}
