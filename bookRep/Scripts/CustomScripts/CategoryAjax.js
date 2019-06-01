function CrudCategory(href,data) {
    $.ajax({
        cache: false,
        type: "POST",
        url: href,
        data: { jsonModel:data},
        success: function (data) {

            if (data.MessageTitle ==="Exception") {
                alert(data.MessageBody);
                return;
            }
            $('#myModal').modal('hide');
           
            if (data.ActionButton !== 'Remove') {
                $('#CategoryName').val(data.CategoryName);
                $('#Description').val(data.Description);
                $('#CategoryId').val(data.CategoryId);

            } else {
                alert("Category removed");

            }
        },
        complete: function (jqXHR, textStatus) {

        }
    });
}

function CrudSubCategory(href, data) {
    $.ajax({
        cache: false,
        type: "POST",
        url: href,
        data: { jsonModel: data },
        success: function (data) {

            if (data.MessageTitle === "Exception") {
                alert(data.MessageBody);
                return;
            }
            $('#myModal').modal('hide');

            if (data.ActionButton !== 'Remove') {
                $('#CategoryId').val(data.CategoryId);
                $('#SubCategoryName').val(data.SubCategory);
                $('#Brand').val(data.BrandName);
                $('#Id').val(data.SubCategoryId);

              
            } else {
                alert("Sub-Category removed");

            }
        },
        complete: function (jqXHR, textStatus) {

        }
    });
}