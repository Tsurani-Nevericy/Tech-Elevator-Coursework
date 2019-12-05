using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            byte i = 0;
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */
            i++;

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;
            Console.WriteLine(i + "). " + remainingNumberOfBirds+" (EXAMPLE)");
            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */
            i++;

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;
            Console.WriteLine(i + "). " + numberOfExtraBirds + " (EXAMPLE)");

            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */
            i++;
            int nRacoons = 3;
            nRacoons -= 2;
            Console.WriteLine(i + "). There is " + nRacoons + " racoon left in the woods.");

            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */
            i++;
            int nFlowers = 5;
            int nBees = 3;
            int nFlowersMoreThanBees = nFlowers - nBees;
            Console.WriteLine(i + "). There are " + nFlowersMoreThanBees+ " less bees than flowers");
            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */
            i++;
            int nLonelyPigeons = 1;
            int nHungryPigeons = 1;
            int nTotalPigeons = nLonelyPigeons + nHungryPigeons;
            Console.WriteLine(i + "). There are " + nTotalPigeons+" pigeons eating breadcrumbs now.");
            /*
            6. 3 owls were sitting on the fence. 2 more owls joined them. How many
            owls are on the fence now?
            */
            i++;
            int nFenceOwls = 3;
            int nJoiningOwls = 2;
            nFenceOwls += nJoiningOwls;
            Console.WriteLine(i + "). There are " + nFenceOwls+" owls on the fence now.");
            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */
            i++;
            int nBeavers = 2;
            nBeavers -= 1;
            Console.WriteLine(i + "). There is " + nBeavers+" beaver still working on its home.");

            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */
            i++;
            int nToucans = 2;
            nToucans += 1;
            Console.WriteLine(i + "). There are " + nToucans+" on the tree limb.");

            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */
            i++;
            int nSquirrels = 4;
            int nNuts = 2;
            int nSquirrelsMoreThanNuts = nSquirrels - nNuts;
            Console.WriteLine(i + "). There are " + nSquirrelsMoreThanNuts+" more squirrels than nuts.");
            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */
            i++;
            const decimal quarter = 0.25M;
            const decimal dime = 0.1M;
            const decimal nickel = 0.05M;
            decimal totalChange = quarter + dime + (2*nickel);
            Console.WriteLine(i + "). Mrs. Hilt found $" + totalChange+".");
            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */
            i++;
            int nBrierMuffins = 18;
            int nAdamsMuffins = 20;
            int nFlannMuffins = 17;
            int nTotalMuffins = nBrierMuffins + nAdamsMuffins + nFlannMuffins;
            Console.WriteLine(i + "). First grade baked " + nTotalMuffins+" muffins in all");
            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */
            i++;
            decimal yoyoCost = 0.24M;
            decimal whistleCost = 0.14M;
            decimal totalCost = yoyoCost + whistleCost;
            Console.WriteLine(i + "). Mrs. Hilt spent $" + totalCost+" in all.");
            /*
            13. Mrs. Hilt made 5 Rice Krispie Treats. She used 8 large marshmallows
            and 10 mini marshmallows.How many marshmallows did she use
            altogether?
            */
            i++;
            int nLargeMarshmallows = 8;
            int nSmallMarshmallows = 10;
            int nTotalMarshmallows = nLargeMarshmallows + nSmallMarshmallows;
            Console.WriteLine(i + "). Mrs. Hilt used " + nTotalMarshmallows+"marshmallows altogether.");
            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */
            i++;
            int nHiltsSnowHeight = 29;
            int nBreckSnowHeight = 17;
            int nHeightDifference = nHiltsSnowHeight - nBreckSnowHeight;
            Console.WriteLine(i + "). Mrs. Hilt received " + nHeightDifference+" more inches of snow than Brecknock Elementary School.");
            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2 on a pencil
            case. How much money does she have left?
            */
            i++;
            decimal balance = 10.00M;
            decimal truckCost = 3.00M;
            balance -= truckCost;
            decimal pencilCost = 2.00M;
            balance -= pencilCost;
            Console.WriteLine(i + "). Mrs. Hilt has $" + balance+" left.");

            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */
            i++;
            int nMarbles = 16;
            nMarbles -= 7;
            Console.WriteLine(i + "). Josh now has " + nMarbles+" marbles left.");

            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */
            i++;
            int nSeaShells = 19;
            int nShellGoal = 25;
            int nRemaining = nShellGoal - nSeaShells;
            Console.WriteLine(i + "). Megan needs " + nRemaining+" more seashells to have a total of "+nShellGoal+".");
            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */
            i++;
            int nBalloons = 17;
            int nRedBalloons = 8;
            int nGreenBalloons = nBalloons - nRedBalloons;
            Console.WriteLine(i + "). Brad has " + nGreenBalloons+" green balloons.");
            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */
            i++;
            int nBooks = 38;
            int nAdded = 10;
            nBooks += nAdded;
            Console.WriteLine(i + "). There are "+nBooks+" books on the shelf now.");
            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */
            i++;
            int nLegsOnBee = 6;
            nBees = 8;
            int nTotalLegs = nBees * nLegsOnBee;
            Console.WriteLine(i + "). Eight bees have a total of "+nTotalLegs+" legs.");
            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */
            i++;
            decimal coneCost = 0.99M;
            decimal coneTotalCost = (2 * coneCost);
            Console.WriteLine(i + "). The cost of 2 ice cream cones is $"+coneTotalCost+".");
            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */
            i++;
            int nTotalRocksRequired = 125;
            int nCurrentRocks = 64;
            int nRocksNeeded = nTotalRocksRequired - nCurrentRocks;
            Console.WriteLine(i + "). Mrs. Hilt needs "+nRocksNeeded+" more rocks to complete her border.");
            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */
            i++;
            int nHiltsMarbles = 38;
            nHiltsMarbles -= 15;
            Console.WriteLine(i + "). Mrs. Hilt now has "+nHiltsMarbles+" marbles left.");
            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */
            i++;
            int nTotalMiles = 78;
            int nMilesSoFar = 32;
            int nMilesRemaining = nTotalMiles - nMilesSoFar;
            Console.WriteLine(i + "). Mrs. Hilt and her sister have "+nMilesRemaining+" miles left to drive.");
            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time did she spend shoveling snow?
            */
            i++;
            int nHours = 1;
            int nMinutes = 30;
            nMinutes += 45;
            nHours = nHours + (nMinutes / 60);
            nMinutes %= 60;
            string sTotalTime = nHours + " hours and " + nMinutes + " minutes.";
            Console.WriteLine(i + "). Mrs. Hilt spent "+sTotalTime+" shoveling snow.");
            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */
            i++;
            decimal hotdogCost = 0.5M;
            int nHotdogs = 6;
            totalCost = hotdogCost * nHotdogs;
            Console.WriteLine(i + "). Mrs. Hilt payed a total of $"+totalCost+" for the hot dogs.");
            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */
            i++;
            balance = 0.5M;
            pencilCost = 0.07M;
            int nAffordablePencils = (int)(balance / pencilCost);
            Console.WriteLine(i + "). Mrs. Hilt can buy "+nAffordablePencils+" pencils with 50 cents.");
            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */
            i++;
            int nButterflies = 33;
            int nOrangeButterflies = 20;
            int nRedButterflies = nButterflies - nOrangeButterflies;
            Console.WriteLine(i + "). There are "+nRedButterflies+" red butterflies.");
            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */
            i++;
            decimal payment = 1.0M;
            decimal candyCost = 0.54M;
            decimal change = payment - candyCost;
            Console.WriteLine(i + "). Kate should receive $"+change+" in change.");
            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */
            i++;
            int nMarksTrees = 13;
            nMarksTrees += 12;
            Console.WriteLine(i + "). Mark will have "+nMarksTrees+" trees in his backyard.");
            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */
            i++;
            int nHoursInADay = 24;
            int nDays = 2;
            int nTimeUntilInHours = nDays * nHoursInADay;
            Console.WriteLine(i + "). Joy will see her grandma in "+nTimeUntilInHours+" hours.");
            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */
            i++;
            int nKimsCousins = 4;
            int nGumForEach = 5;
            int nTotalGum = nKimsCousins * nGumForEach;
            Console.WriteLine(i + "). Kim will need a total of "+nTotalGum+" pieces of gum.");
            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */
            i++;
            balance = 3.00M;
            balance -= 1.00M;
            Console.WriteLine(i + "). Dan will have $"+balance+" left.");
            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */
            i++;
            int nBoats = 5;
            int nPassengersPerBoat = 3;
            int nTotalBoaters = nBoats * nPassengersPerBoat;
            Console.WriteLine(i + "). There are a total of "+nTotalBoaters+" people on boats in the lake.");
            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */
            i++;
            int nLegos = 380;
            nLegos -= 57;
            Console.WriteLine(i + "). Ellen now has "+nLegos+" legos left.");
            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */
            i++;
            int nMuffins = 35;
            int nMuffinGoal = 83;
            int nMuffinsNeeded = nMuffinGoal - nMuffins;
            Console.WriteLine(i + "). Arthur will need to bake another "+nMuffinsNeeded+" to have a total of 83.");
            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */
            i++;
            int nWillysCrayons = 1400;
            int nLucysCrayons = 290;
            int nCrayonDifference = nWillysCrayons - nLucysCrayons;
            Console.WriteLine(i + "). Willy has "+nCrayonDifference+" more crayons than Lucy.");
            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */
            i++;
            int nStickersPerPage = 10;
            int nPages = 22;
            int nTotal = nStickersPerPage * nPages;
            Console.WriteLine(i + "). I would have a total of "+nTotal+" stickers.");
            /*
            39. There are 96 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */
            i++;
            int nTotalCupcakes = 96;
            int nChildren = 8;
            int nCupcakesEach = nTotalCupcakes / nChildren;
            Console.WriteLine(i + "). Each person would get "+nCupcakesEach+" cupcakes.");
            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies each, how many
            cookies will not be placed in a jar?
            */
            i++;
            int nGingerBreadCookies = 47;
            int nCookiesPerJar = 6;
            int nJarlessCookies = nGingerBreadCookies % nCookiesPerJar;
            Console.WriteLine(i + "). There will be "+nJarlessCookies+" cookies not in a jar.");
            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received and equal number of croissants,
            how many will be left with Marian?
            */
            i++;
            int nCroissants = 59;
            int nMoochers = 8;
            int nLeftover = nCroissants % nMoochers;
            Console.WriteLine(i + "). Marian will have "+nLeftover+" leftover croissants.");
            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */
            i++;
            int nTotalCookies = 276;
            int nCookiesPerBatch = 12;
            int nTrays = nTotalCookies / nCookiesPerBatch;
            Console.WriteLine(i + "). Marian will need a total of "+nTrays+" trays to prepare 276 cookies at a time.");
            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */
            i++;
            int nTotalPrezels = 480;
            int nPrezelsPerServing = 12;
            int nTotalServings = nTotalPrezels / nPrezelsPerServing;
            Console.WriteLine(i + "). Marian will be able to produce "+nTotalServings+" servings of prezels.");
            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */
            i++;
            nTotalCupcakes = 53;
            nTotalCupcakes -= 2;
            int nCupcakesPerBox = 3;
            int nCupcakeBoxesGivenAway = nTotalCupcakes / nCupcakesPerBox;
            Console.WriteLine(i + "). Marian gave away "+nCupcakeBoxesGivenAway+" boxes of lemon cupcakes.");
            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */
            i++;
            int nTotalCarrots = 74;
            int nPeople = 12;
            int nLeftoverCarrots = nTotalCarrots % nPeople;
            Console.WriteLine(i + "). There were "+nLeftoverCarrots+" carrot sticks left over");
            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */
            i++;
            int nTotalTeddys = 98;
            int nTeddysPerShelf = 7;
            int nShelvesFilled = nTotalTeddys / nTeddysPerShelf;
            Console.WriteLine(i + "). Susie and her sister could fill "+nShelvesFilled+" shelves with teddy bears.");
            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */
            i++;
            int nAlbumCapacity = 20;
            int nTotalPictures = 480;
            int nAlbums = nTotalPictures / nAlbumCapacity;
            Console.WriteLine(i + "). Susie's mother needs "+nAlbums+" albums.");
            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */
            i++;
            int nTotalCards = 94;
            int nFullBox = 8;
            int nFullBoxes = nTotalCards / nFullBox;
            int nCardsInLeftoversBox = nTotalCards % nFullBox;
            Console.WriteLine(i + "). There are " + nFullBoxes + " filled boxes and " + nCardsInLeftoversBox + " cards in the unfilled box.");
            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */
            i++;
            nBooks = 210;
            int nBookshelves = 10;
            int nBooksPerShelf = nBooks / nBookshelves;
            Console.WriteLine(i + "). Each bookshelf will contain "+nBooksPerShelf+" books.");
            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */
            i++;
            nCroissants = 17;
            nMoochers = 7;
            int nCroissantsEach = nCroissants / nMoochers;
            Console.WriteLine(i + "). Christina could serve "+nCroissantsEach+" croissants to each guest.");
            /*
                CHALLENGE PROBLEMS
            */

            /*
            Bill and Jill are house painters. Bill can paint a 12 x 14 room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painter working together to paint 5 12 x 14 rooms?
            Hint: Calculate the hourly rate for each painter, combine them, and then divide the total walls in feet by the combined hourly rate of the painters.
            Challenge: How many days will it take the pair to paint 623 rooms assuming they work 8 hours a day?.
            */
            i -= 49;
            int n = 1;
            float fBillRoomsPerHour = 1.0f / 2.15f;
            float fJillRoomsPerHour = 1.0f / 1.90f;
            float fCombinedRoomsPerHour = fBillRoomsPerHour + fJillRoomsPerHour;
            float nTimeUntil5Rooms = 5.0f / fCombinedRoomsPerHour;
            Console.WriteLine("Challenge #" + i + "." + n + "). It would take Bill and Jill "+nTimeUntil5Rooms+" hours to paint 5 rooms.");
            n++;
            float fHoursPerDay = 8.0f;
            float fHoursInADay = 24.0f;
            float fPercentOfDayWorking = fHoursPerDay / fHoursInADay;
            float fTimeUntil623Rooms = (623.0f / fCombinedRoomsPerHour) * (1/fPercentOfDayWorking);
            fTimeUntil623Rooms /= 24.0f;
            int nDaysToPaint = (int)fTimeUntil623Rooms;
            fTimeUntil623Rooms -= nDaysToPaint;
            fTimeUntil623Rooms *= 24.0f;
            int nHoursToPaint = (int)fTimeUntil623Rooms;
            fTimeUntil623Rooms -= nHoursToPaint;
            fTimeUntil623Rooms *= 60.0f;
            int nMinutesToPaint = (int)fTimeUntil623Rooms;
            fTimeUntil623Rooms -= nMinutesToPaint;
            fTimeUntil623Rooms *= 60.0f;
            int nSecondsToPaint = (int)fTimeUntil623Rooms;
            fTimeUntil623Rooms -= nSecondsToPaint;
            fTimeUntil623Rooms *= 1000.0f;
            int nMilisToPaint = (int)fTimeUntil623Rooms;
            Console.WriteLine("Challenge #"+ i + "." + n + "). It will take Bill and Jill " + nDaysToPaint + " days to Paint 623 12x14 Rooms.");
            Console.WriteLine("Challenge #" + i + "." + n + ".a). It will take Bill and Jill " + nDaysToPaint + " days, " + nHoursToPaint + " hours, " + nMinutesToPaint + " minutes, " + nSecondsToPaint + " seconds, and " + nMilisToPaint + " milliseconds to Paint 623 12x14 Rooms.");
            /*
            Create and assign variables to hold your first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold your full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period.
            Example: "Hopper, Grace B."
            */
            i++;
            n = 1;
            string sFirstName = "Cameron";
            string sLastName = "Pleshek";
            string sMiddleIni = "A";

            string sFullName = $"{sLastName}, {sFirstName} {sMiddleIni}.";
            Console.WriteLine("Challenge #" + i + "." + n +").Full Name : " +sFullName);
            /*
            The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip has been completed?
            Hint: The percent completed is the miles already travelled divided by the total miles.
            Challenge: Display as an integer value between 0 and 100 using casts.
            */
            i++;
            n = 1;
            float fTotalDistance = 800.0f;
            float fTravelledDistance = 537.0f;
            float fPercentCompleted = (fTravelledDistance / fTotalDistance);
            Console.WriteLine("Challenge #" + i + "." + n + "). The trip is "+fPercentCompleted+"% Completed.");
            n++;
            fPercentCompleted *= 100.0f;
            int nPercentCompleted = (int)fPercentCompleted;
            Console.WriteLine("Challenge #" + i + "." + n + "). The trip is "+nPercentCompleted+"% Completed.");
            Console.ReadKey();
        }
    }
}
