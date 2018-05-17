using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RootFamilyApp.Models
{
    public enum IndividualEventType
    {
        /// <summary>
        /// ADOP- Pertaining to creation of a legally approved child-parent relationship that does not exist biologically.
        /// </summary>
        Adoption = 0,
        /// <summary>
        /// BIRT - The event of entering into life.
        /// </summary>
        Birth = 1,
        /// <summary>
        /// BAPM - The event of baptism (not LDS), performed in infancy or later.
        /// </summary>
        Baptism = 2,
        /// <summary>
        /// BARM - The ceremonial event held when a Jewish boy reaches age 13.
        /// </summary>
        BarMitzvah = 3,
        /// <summary>
        /// BASM - The ceremonial event held when a Jewish girl reaches age 13, also known as "Bat Mitzvah".
        /// </summary>
        BasMitzvah = 4,
        /// <summary>
        /// BLES - A religious event of bestowing divine care or intercession. Sometimes given in connection with a naming ceremony.
        /// </summary>
        Blessing = 5,
        /// <summary>
        /// BURI - The event of the proper disposing of the mortal remains of a deceased person.
        /// </summary>
        Burial = 6,
        /// <summary>
        /// CENS- The event of the periodic count of the population for a designated locality, such as a national or state Census.
        /// </summary>
        Census = 7,
        /// <summary>
        /// CHR - The religious event (not LDS) of baptizing and/or naming a child.
        /// </summary>
        Christiening = 8,
        /// <summary>
        /// CHRA - The religious event (not LDS) of baptizing and/or naming an adult person.
        /// </summary>
        AdultChristiening = 9,
        /// <summary>
        /// CONF - The religious event (not LDS) of conferring the gift of the Holy Ghost and, among protestants, full church membership.
        /// </summary>
        Confirmation = 10,
        /// <summary>
        /// CREM - Disposal of the remains of a person's body by fire.
        /// </summary>
        Cremation = 11, // 
        /// <summary>
        /// DEAT - The event when mortal life terminates.
        /// </summary>
        Death = 12,
        /// <summary>
        /// EMIG - An event of leaving one's homeland with the intent of residing elsewhereAn event of leaving one's homeland with the intent of residing elsewhere.
        /// </summary>
        Emigration = 13,
        /// <summary>
        /// FCOM - A religious rite, the first act of sharing in the Lord's supper as part of church worship.
        /// </summary>
        FirstCommunion = 14,
        /// <summary>
        /// GRAD - An event of awarding educational diplomas or degrees to individuals.
        /// </summary>
        Graduation = 15,
        /// <summary>
        /// IMMI - An event of entering into a new locality with the intent of residing there.
        /// </summary>
        Immigration = 16,
        /// <summary>
        /// NATU - The event of obtaining citizenship.
        /// </summary>
        Naturalization = 17,
        /// <summary>
        /// ORDN - A religious event of receiving authority to act in religious matters.
        /// </summary>
        Ordination = 18,
        /// <summary>
        /// RETI - An event of exiting an occupational relationship with an employer after a qualifying time period.
        /// </summary>
        Retirement = 19,
        /// <summary>
        /// PROB - An event of judicial determination of the validity of a will. May indicate several related court activities over several dates.
        /// </summary>
        Probate = 20,
        /// <summary>
        /// WILL - A legal document treated as an event, by which a person disposes of his or her estate, to take effect after death. The event date is the date the will was signed while the person was alive.
        /// </summary>
        Will = 21,
        /// <summary>
        /// EVEN - Pertaining to a noteworthy happening related to an individual, a group, or an organization. An EVENt structure is usually qualified or classified by a subordinate use of the TYPE tag.
        /// </summary>
        Event = 22
    }
}