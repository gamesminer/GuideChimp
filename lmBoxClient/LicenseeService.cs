﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lmBoxClient.RestController;
using lmBoxClient.Entities;
using System.Data;

namespace lmBoxClient
{
    /// <summary>
    /// C# representation of the Licensee Service. See lmBoxAPI JavaDoc for details:
    /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
    /// </summary>
    public class LicenseeService
    {
        /// <summary>
        /// Creates new licensee object with given properties. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static Licensee create(Context context, String productNumber, Licensee newLicensee)
        {
            newLicensee.productNumber = productNumber;
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.POST, "/licensee", newLicensee.ToDictionary());

            List<Licensee> licensees = new List<Licensee>();
            foreach (item i in output.items)
            {
                licensees.Add(new Licensee(i));
            }
            return null;
        }

        /// <summary>
        /// Gets licensee by its number. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static Licensee get(Context context, String number)
        {
            // TODO: Stub
            return null;
        }

        /// <summary>
        /// Returns all licensees of a vendor. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static List<Licensee> list(Context context)
        {
            lmbox output = LmBoxAPI.request(context, LmBoxAPI.Method.GET, "/licensee", null);

            // TODO: process output.infos
            List<Licensee> licensees = new List<Licensee>();
            foreach (item i in output.items)
            {
                licensees.Add(new Licensee(i));
            }
            return licensees;
        }

        /// <summary>
        /// Updates licensee properties. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static Licensee update(Context context, String number, Licensee updateLicensee)
        {
            // TODO: Stub
            return null;
        }

        /// <summary>
        /// Deletes licensee. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static void delete(Context context, String number, bool forceCascade)
        {
            // TODO: Stub
            return;
        }

        /// <summary>
        /// Validates active licenses of the licensee. See lmBoxAPI JavaDoc for details:
        /// http://lmbox.labs64.com/javadoc/index.html?com/labs64/lmbox/core/service/LicenseeService.html
        /// </summary>
        public static ValidationResult validate(Context context, String number)
        {
            // TODO: Stub
            return null;
        }

    }
}
