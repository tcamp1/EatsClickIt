$("#add-preparation").click(function () {

    $("#preparation-table").each(function () {

        var preparationCount = $("#preparation-count").val();

        $("#preparation-count").val(parseInt(preparationCount) + 1);

        var tds = '<tr>';

        tds += '<td>';
        tds += '<input data-val="true" data-val-number="The field Preparation ID must be a number." data-val-required="The Preparation ID field is required." id="Preparations_' + preparationCount + '__PreparationId" name="Preparations[' + preparationCount + '].PreparationId" type="hidden" value="-1" />';
        tds += '<input data-val="true" data-val-number="The field Meal Plan ID must be a number." data-val-required="The Meal Plan ID field is required." id="Preparations_' + preparationCount + '__MealPlanId" name="Preparations[' + preparationCount + '].MealPlanId" type="hidden" value="-1" />';
        tds += '<input class="form-control" data-val="true" data-val-number="The field Sequence must be a number." data-val-required="The Sequence field is required." id="Preparations_' + preparationCount + '__Sequence" name="Preparations[' + preparationCount + '].Sequence" type="text" value="0" />';
        tds += '</td>';

        tds += '<td>';
        tds += '<textarea class="form-control" cols="20" id="Preparations_' + preparationCount + '__Instruction" name="Preparations[' + preparationCount + '].Instruction" rows="5" style="resize:both;min-width: 100%"></textarea>';
        tds += '</td>';

        tds += '</tr>';

        if ($('tbody', this).length > 0) {
            $('tbody', this).append(tds);
        } else {
            $(this).append(tds);
        }
    });
});

$("#add-nutrient").click(function () {

    var $nutrientCount = $("#nutrient-count").val();
    $("#nutrient-count").val(parseInt($nutrientCount) + 1);

    var $lastRow = $("[id$=nutrient-table] tr:last");                      // grab row the last row
    var $newRow = $lastRow.clone();                                        // clone it
    var regex;

    //TODO: Set values to 0
    $newRow.find("[id$=MealPlanAssignedNutrientId]").val(-1);
    $newRow.find("[id$=NutrientId]").val(-1);
    $newRow.find("[id$=Quantity]").val(0);
    $newRow.find("[id$=UomId]").val(-1);

    // Reset the name and id of all the controls
    $newRow.find('[id*="MealPlanAssignedNutrients"]').each(function () {
        regex = new RegExp('MealPlanAssignedNutrients\\[\\d+');
        $(this).attr('name', $(this).attr('name').replace(regex, 'MealPlanAssignedNutrients\[' + $nutrientCount));
        regex = new RegExp('MealPlanAssignedNutrients_\\d+');
        $(this).attr('id', $(this).attr('id').replace(regex, 'MealPlanAssignedNutrients\_' + $nutrientCount));
    });

    $lastRow.after($newRow);                                               // add in the new row at the end
});


$("#add-dish").click(function () {

    var $dishCount = $("#dish-count").val();
    $("#dish-count").val(parseInt($dishCount) + 1);

    var $lastRow = $("[id$=dish-table] tr:last");                      // grab row the last row
    var $newRow = $lastRow.clone();                                        // clone it
    var regex;

    //TODO: Set values to 0
    $newRow.find("[id$=MealPlanAssignedDishId]").val(-1);
    $newRow.find("[id$=DishId]").val(-1);

    // Reset the name and id of all the controls
    $newRow.find('[id*="MealPlanAssignedDishes"]').each(function () {
        regex = new RegExp('MealPlanAssignedDishes\\[\\d+');
        $(this).attr('name', $(this).attr('name').replace(regex, 'MealPlanAssignedDishes\[' + $dishCount));
        regex = new RegExp('MealPlanAssignedDishes_\\d+');
        $(this).attr('id', $(this).attr('id').replace(regex, 'MealPlanAssignedDishes\_' + $dishCount));
    });

    $lastRow.after($newRow);                                               // add in the new row at the end
});

$("#add-ingredient").click(function () {

    var $ingredientCount = $("#ingredient-count").val();
    $("#ingredient-count").val(parseInt($ingredientCount) + 1);

    var $lastRow = $("[id$=ingredient-table] tr:last");                      // grab row the last row
    var $newRow = $lastRow.clone();                                        // clone it
    var regex;

    //TODO: Set values to 0
    $newRow.find('[id*="IngredientId"]').each(function () {
        $(this).val(-1);
    });

    // $newRow.find("[id$=MealPlanAssignedIngredientId]").val(-1);
    // $newRow.find("[id$=IngredientId]").val(-1);
    $newRow.find("[id$=Quantity]").val(0);
    $newRow.find("[id$=UomId]").val(-1);

    // Reset the name and id of all the controls
    $newRow.find('[id*="MealPlanAssignedIngredients"]').each(function () {
        regex = new RegExp('MealPlanAssignedIngredients\\[\\d+');
        $(this).attr('name', $(this).attr('name').replace(regex, 'MealPlanAssignedIngredients\[' + $ingredientCount));
        regex = new RegExp('MealPlanAssignedIngredients_\\d+');
        $(this).attr('id', $(this).attr('id').replace(regex, 'MealPlanAssignedIngredients\_' + $ingredientCount));
    });

    $lastRow.after($newRow);                                               // add in the new row at the end
});
