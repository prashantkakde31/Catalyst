        var itemCount = 0;
        var containerRecommendedDiet = "#RecommendedDietSection ";

        var objs = [];
        var temp_objs = [];


        //function addFoodRow(MealId) {
        function addRecommendedFoodRow(MealId) {
            //$("#add_button").click(function () {
            debugger;
            var html = "";
            //var foodName = $("#txtFoodItemMeal1").val();
            var foodName = $(containerRecommendedDiet + "#txtFoodItem" + MealId).val();
            var foodQuantity = $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val();
            var foodUnit = $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val();

            if (foodName == '' || foodQuantity == '' || foodUnit == '')
                return;

            var foodNutrients;


            debugger;
            $.ajax({
                type: "POST",
                url: "../Screens/DietHelper.aspx/GetFoodNutrients",
                data: '{FoodName: "' + foodName + '",foodQuantity: "' + foodQuantity + '",foodUnit: "' + foodUnit + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert(response.d);
                    //notie.alert(1, 'Success!', 2);
                    foodNutrients = response.d;
                },
                failure: function (response) {
                    //alert(response.d);
                }
            });

            var obj = {
                "ROW_ID": itemCount,
                "FOOD_ID": foodNutrients.foodID,
                "FOOD_NAME": $(containerRecommendedDiet + "#txtFoodItem" + MealId).val(),
                "FOOD_QUANTITY": $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val(),
                "FOOD_UNIT": $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val(),
                "FOOD_REMARK": $(containerRecommendedDiet + "#txtFoodRemark" + MealId).val(),
                "FOOD_ENERGY": foodNutrients.energy,
                "FOOD_PROTEIN": foodNutrients.protein,
                "FOOD_FAT": foodNutrients.fat,
                "FOOD_FIBRE": foodNutrients.fibre,
                "FOOD_CARBS": foodNutrients.carbs,
            }

            // add object
            objs.push(obj);

            itemCount++;
            // dynamically create rows in the table
            html += "<tr id='tr" + itemCount + "'>";
            html += "   <td class='mealInput hidden'>" + obj['FOOD_ID'] + "</td>";
            html += "   <td colspan='2'>" + obj['FOOD_NAME'] + "</td>";
            html += "   <td class='mealInput'>" + obj['FOOD_QUANTITY'] + " </td>";
            html += "   <td class='mealInput'>" + obj['FOOD_UNIT'] + " </td>";
            html += "   <td class='mealInput'>" + obj['FOOD_REMARK'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_ENERGY'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_PROTEIN'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FAT'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FIBRE'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_CARBS'] + " </td>";
            html += "   <td class='action'><input type='button'  id='" + itemCount + "' value='remove' onclick='removeRecommendedFoodRow(&quot;" + MealId + "&quot; , this)'></td>";
            html += "</tr>";



            //add to the table
            $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] > tbody:last").append(html);

            calculateRecommendedDietTotal(MealId);

            $(containerRecommendedDiet + "#txtFoodItem" + MealId).val("");
            $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val("");
            $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val("");
            $(containerRecommendedDiet + "#txtFoodRemark" + MealId).val("");



        }

//function removeFoodRow(MealId, removeButton) {
        function removeRecommendedFoodRow(MealId, removeButton) {
            $(removeButton).parent().parent().remove();
            calculateRecommendedDietTotal(MealId);
        }

//function calculateTotal(MealId) {
        function calculateRecommendedDietTotal(MealId) {
            var totals = [0, 0, 0, 0, 0];

            var $dataRows = $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    totals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

            $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol").each(function (i) {
                $(this).html(totals[i].toFixed(2));
            });

            //Overall Total
            calculateRecommendedDietAllTotal();
        }

//function calculateAllTotal() {
        function calculateRecommendedDietAllTotal() {
            var totals = [0, 0, 0, 0, 0];
            var sel48DietRecallOrNot = "[role!='RecallDiet48Hour']";

            if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
                sel48DietRecallOrNot = "";
            }


            var $dataRows = $(containerRecommendedDiet + "table[id*='tblFoodListMeal']" + sel48DietRecallOrNot + " tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    totals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

            $("table[id='tblFoodListTotal'] td").each(function (i) {
                $(this).html(totals[i].toFixed(2));
            });
        }

//function saveMeal(MealId) {
        function saveRecommendedDietMeal(MealId) {
            var weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
            var mealDays = "";
            var mealData = "";
            var mealTime = $(containerRecommendedDiet + "input[id$='txtTimePicker" + MealId + "']").val().trim();
            var notes = $(containerRecommendedDiet + "textarea[id$='txtRecallDietNotes']").val().trim();


            $(containerRecommendedDiet + "input[id*='chkDays" + MealId + "_']:checked").each(function () {
                mealDays = mealDays + weekDays.indexOf($(this).val()) + "-";
            });

            mealDays = mealDays.substr(0, mealDays.lastIndexOf("-"));

            //alert(mealDays);


            var $dataRows = $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.mealInput').each(function () {
                    mealData = mealData + $(this).html().trim() + "|";
                });
                mealData = mealData.substr(0, mealData.lastIndexOf("|"));
                mealData = mealData + "~";
            });

            mealData = mealData.substr(0, mealData.lastIndexOf("~"));

            //alert(mealData);

            $.ajax({
                type: "POST",
                url: "../Screens/DietHelper.aspx/SaveRecommendedSingleMealDetails",
                data: '{MealID: "' + MealId + '", MealDays: "' + mealDays + '", MealData: "' + mealData + '", MealTime: "' + mealTime + '", Notes: "' + notes + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert(response.d);
                    $(containerRecommendedDiet + "input[id='btnSave" + MealId + "']").notify(
                      "Saved",
                      { position: "right", className: 'success' }
                    );

                    //$.notify("Saved", "success");

                    foodNutrients = response.d;
                },
                failure: function (response) {
                    //alert(response.d);
                    $(containerRecommendedDiet + "input[id='btnSave" + MealId + "']").notify(
                      "Error",
                      { position: "right", className: 'error' }
                    );
                }
            });


        }

//function saveAllMeals() {
        function saveAllRecommendedDietMeals() {
            var mealName = "Meal";
            var length = 6;

            if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
                length = 12;
            }
            for (var meal = 1; meal <= length; meal++) {
                saveRecommendedDietMeal(mealName + meal);
            }

            $(containerRecommendedDiet + "input[id='btnSaveAllMeals']").notify(
              "Saved",
              { position: "right", className: 'success' }
            );

        }

        function setDietRecommendedType() {
            if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
                $(containerRecommendedDiet + "div[role='RecallDiet48Hour'").show();
            }
            else {
                $(containerRecommendedDiet + "div[role='RecallDiet48Hour'").hide();
            }
            calculateRecommendedDietAllTotal();
        }

        function selectRecommendedDays(ctrl,mealId) {
            var check = $(ctrl).is(':checked');
            var ctrlValue = $(ctrl).attr("value");
            var weekDay = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
            var weekEnd = ["Saturday", "Sunday"];

            switch (ctrlValue) {
                case "Alldays":
                    //alert('All' + mealId);
                    $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {
                        $(this).prop("checked", check);
                    });
                    $(containerRecommendedDiet + "input[id^='chkWeekdays" + mealId + "']").prop("checked", false);
                    $(containerRecommendedDiet + "input[id^='chkWeekend" + mealId + "']").prop("checked", false);
                    break;

                case "Weekdays":
                    //alert('Weekday' + mealId);
                    $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                        if (weekDay.indexOf($(this).val()) > -1) {
                            $(this).prop("checked", check);
                        }
                        else
                        {
                            $(this).prop("checked", false);
                        }
                    });
                    $(containerRecommendedDiet + "input[id^='chkAlldays" + mealId + "']").prop("checked", false);
                    $(containerRecommendedDiet + "input[id^='chkWeekend" + mealId + "']").prop("checked", false);
                    break;

                case "Weekend":
                    //alert('Weekend' + mealId);
                    $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                        if (weekEnd.indexOf($(this).val()) > -1) {
                            $(this).prop("checked", check);
                        }
                        else {
                            $(this).prop("checked", false);
                        }
                    });
                    $(containerRecommendedDiet + "input[id^='chkWeekdays" + mealId + "']").prop("checked", false);
                    $(containerRecommendedDiet + "input[id^='chkAlldays" + mealId + "']").prop("checked", false);
                    break;

                default:
                    break;
            }

        }
