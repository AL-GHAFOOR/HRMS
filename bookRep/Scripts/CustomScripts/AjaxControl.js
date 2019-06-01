function onsubmit_post(href, e) {
    try {
        //ModalShow('/Home/Index');
        /*--------------------------------- LOAD Watiting---------------------*/
        //var renderBody = $('#detialsPage');
        //renderBody.empty();
        //$(renderBody).load("/LoadingPage.html", function () {
        //    $(this).clone().appendTo("body").remove();
        //});$('#myModal').modal({
        //    show: true,
        //    backdrop: 'static',
        //    keyboard: false
        //});
        /*--------------------------------- LOAD Watiting---------------------*/


        $.ajax({
            cache: false,
            type: "POST",
            url: href,
            success: function (data) {

                var renderBody = $('#bodyContent');
                renderBody.empty();
                renderBody.append(data);

                // Remove All Tab Selected
                //$('#navSelectd').find('li').each(function () {
                //    $(this).removeClass('active');

                //});
                //// Active Tab 
                //var linkActive = $(e).closest("li").addClass('active');

            },
            complete: function (jqXHR, textStatus) {
                //$('#myModal').modal('hide');
                //$('#myModal').modal('hide');
                //var counter = 0;
                //var interval = setInterval(function () {
                //    counter++;
                //    // Display 'counter' wherever you want to display it.
                //    if (counter === 3) {
                //        // Display a login box
                //        clearInterval(interval);

                //    }
                //}, 100);

            }
        });
    } catch (e) {
        alert(e.error);

    }

}
function LoadPage(href, e) {
    try {
        //ModalShow('/Home/Index');
        /*--------------------------------- LOAD Watiting---------------------*/
        //var renderBody = $('#detialsPage');
        //renderBody.empty();
        //$(renderBody).load("/LoadingPage.html", function () {
        //    $(this).clone().appendTo("body").remove();
        //});$('#myModal').modal({
        //    show: true,
        //    backdrop: 'static',
        //    keyboard: false
        //});
        /*--------------------------------- LOAD Watiting---------------------*/


        $.ajax({
            cache: false,
            type: "GET",
            url: href,
            success: function (data) {

                var renderBody = $('#bodyContent');
                renderBody.empty();
                renderBody.append(data);

                // Remove All Tab Selected
                //$('#navSelectd').find('li').each(function () {
                //    $(this).removeClass('active');

                //});
                //// Active Tab 
                //var linkActive = $(e).closest("li").addClass('active');

            },
            complete: function (jqXHR, textStatus) {
                //$('#myModal').modal('hide');
                //$('#myModal').modal('hide');
                //var counter = 0;
                //var interval = setInterval(function () {
                //    counter++;
                //    // Display 'counter' wherever you want to display it.
                //    if (counter === 3) {
                //        // Display a login box
                //        clearInterval(interval);

                //    }
                //}, 100);

            }
        });
    } catch (e) {
        alert(e.error);

    }

}
function SelectCategoryLoad(href) {
    $.ajax({
        cache: false,
        type: "POST",
        url: href,
        data: { ProductId: $('#ProductCode').val() },
        success: function (data) {
            $('#lblProductCode').empty();
            $('#lblSubCategoryName').empty();
            $('#lblCategoryName').empty();
            $('#lblProductType').empty();
            if (data.TrackStatus === 'Track') {
                $('#lblProductType').append('Long-term asset');
            } else {
                $('#lblProductType').append('Short-term asset');
            }

            $('#lblCategoryName').append(data.CatName);
            $('#lblSubCategoryName').append(data.SubCatName);
            $('#lblProductCode').append(data.ProductCode);

        },
        complete: function (jqXHR, textStatus) {


        }
    });
}
function ChartData(href) {
    var list = "";
    $.ajax({
        cache: false,
        type: "GET",
        url: href,
        success: function (data) {

            list = data;


        }
    });
    return list;
}
function TestAlert(value) {
    dynamicPageLoad('/Detials/AssetList?productCode=' + value, '#productList');


}

//$(".dropdown-menu li a").click(function () {
//    alert($(this).text());
//    //$(".btn:first-child").text($(this).text());
//    $(this).val($(this).text());
//});
function LoadPagePost(href, data) {

    $.ajax({
        cache: false,
        type: "POST",
        url: href,
        data: { jsonModel: data },
        success: function (data) {

            var renderBody = $('#content');
            renderBody.empty();
            renderBody.append(data);
            $('#myModal').modal('hide');
        },
        complete: function (jqXHR, textStatus) {
            $('#myModal').modal('hide');


        }
    });
}

function dynamicPageLoad(href, content) {
    try {

        $.ajax({
            cache: false,
            type: "GET",
            url: href,
            success: function (result) {
               
                $(content).empty();
                $(content).append(result);
            },
            complete: function (jqXHR, textStatus) {


            }
        });
    } catch (error) {
        alert(error);

    }
}
function NoTrackItemAdd(href, content) {
    try {

        var Qty = $('#Qty').val();
        var link = href + "&Qty=" + Qty;

        $.ajax({
            cache: false,
            type: "POST",
            url: link,
            success: function (result) {
                $(content).empty();

                $(content).append(result);

            },
            complete: function (jqXHR, textStatus) {


            }
        });
    } catch (error) {
        alert(error);

    }
}
function reportLoad(href, content, form) {
    try {
        var data = $(form).serialize();
        $.ajax({
            cache: false,
            type: "POST",
            url: href,
            data: data,
            success: function (result) {
                $(content).empty();

                $(content).append(result);

            },
            complete: function (jqXHR, textStatus) {


            }
        });
    } catch (error) {
        alert(error);

    }
}
function PagePost(href, dataToPost) {
    // var userObj = JSON.parse(e);
    //data: JSON.stringify(dataToPost)
    var data = $(dataToPost).serialize();
    try {
        if ($(dataToPost).valid()) {

            $.ajax({
                cache: false,
                type: "POST",
                url: href,
                data: data,
                success: function (data) {
                    if (data.MessageTitle === "Exception") {
                        alert(data.MessageBody);
                        return false;
                    }

                    alert(data.MessageBody);
                    
                    $(dataToPost)[0].reset();
                },
                complete: function (jqXHR, textStatus) {

                }
            });
        }

    } catch (e) {
        alert(e);
    }


}

function ModalShowWithClose(href) {
    $.ajax({
        cache: false,
        type: "GET",
        url: href,
        success: function (data) {
            var renderBody = $('#detialsPage');
            renderBody.empty();
            renderBody.append(data);
           // $('#myModal').modal('show');
            $('#myModal').modal({
                show: true,
                backdrop: 'static',
                keyboard: true
        });


        },
        complete: function (jqXHR, textStatus) {

        }
    });
}

function ModalShow(href) {
    $.ajax({
        cache: false,
        type: "GET",
        url: href,
        success: function (data) {
            var renderBody = $('#detialsPage');
            renderBody.empty();
            renderBody.append(data);
            $('#myModal').modal({
                show: true,
                backdrop: 'static',
                keyboard: false
            });


        },
        complete: function (jqXHR, textStatus) {

        }
    });
}

function PopUpModel(e) {
    $('#myModal').modal('toggle');

}
function SelectBrandLoad() {
    var catId = $('#SubCategoryId').val();

    $("#BrandName").empty();
    try {

        $.ajax({
            cache: false,
            type: "POST",
            url: '/Master/BrandLoadBySubCategory/',
            data: { SubCatid: catId },
            success: function (result) {

                $("#BrandName").val(result[0].BrandName);
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }

}
function SelectSubCategoryLoad() {
    var catId = $('#CategoryId').val();
    $("#SubCategoryId").empty();
    try {
        $.ajax({
            cache: false,
            type: "POST",
            url: '/Master/SubCategoryLoadByCatId/',
            data: { Id: catId },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#SubCategoryId").append('<option value="'
                        + data.Value + '">'
                        + data.Text + '</option>');
                });
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }

}
function CategoryLoad() {
    $("#CategoryId").empty();
    try {
        $.ajax({
            cache: false,
            type: "POST",
            url: '/Master/CategoryLoad',

            success: function (data) {
                $.each(data, function (i, data) {
                    $("#CategoryId").append('<option value="'
                        + data.Value + '">'
                        + data.Text + '</option>');
                });
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }

}

function NewProduct() {
    $("#ProductCode").empty();
    try {
        $.ajax({
            cache: false,
            type: "POST",
            url: '/Master/ProductLoad',

            success: function (data) {
                $.each(data, function (i, data) {
                    $("#ProductCode").append('<option value="'
                        + data.Value + '">'
                        + data.Text + '</option>');
                });
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }

}
function SupplierLoad() {
    $("#SupplierId").empty();
    try {
        $.ajax({
            cache: false,
            type: "POST",
            url: '/Master/SupplierLoad',

            success: function (data) {
                $.each(data, function (i, data) {
                    $("#SupplierId").append('<option value="'
                        + data.Value + '">'
                        + data.Text + '</option>');
                });
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }

}
function AddToList(href, content) {
    try {
        var data = $("#submitform").serialize();

        if ($('#submitform').valid()) {
            $.ajax({
                cache: false,
                type: "POST",
                url: href,
                data: data,
                success: function (result) {
                    $(content).empty();
                    $(content).append(result);


                },
                complete: function (jqXHR, textStatus) {
                    $('input[id=ProductName]').val('');
                    $('input[id=Product_ProductCode]').val('');
                    $('input[id=BrandName]').val('');
                    $('input[id=WarrantyDate]').val('');
                    $('input[id=Qty]').val('');
                    $('input[id=UnitPrice]').val('');
                    $('textarea[id=ProductDesc]').val('');
                    $('select[id=Product_ProducatUnit]').val("");

                    $('#CategoryId').val("").trigger('change');


                }
            });
        }
    } catch (error) {
        alert(error);

    }
}
function RemoveItem(href, content, ProductId) {
    try {
        $.ajax({
            cache: false,
            type: "POST",
            url: href,
            data: { Id: ProductId },
            success: function (result) {
                $(content).empty();
                $(content).append(result);
            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }
}

function EditItem(href, content, product) {
    try {
        // var formValue = $(product).serialize();
        $.ajax({
            cache: false,
            type: "GET",
            url: href,
            data: { ProductCode: product },
            success: function (result) {
                $(content).empty();
                $(content).append(result);

            },
            complete: function (jqXHR, textStatus) {

            }
        });
    } catch (error) {
        alert(error);

    }


}
function SaveProduct(href, dataToPost) {

    //var data = $(dataToPost).serialize();
    // var fileUpload = $('#fileName').get(0);
    var data = new FormData($(dataToPost)[0]);
    //var files = fileUpload.files[0];
    //data += "&fileName="+files;
    try {

        if ($(dataToPost).valid()) {

            //alert(file);
            $.ajax({
                cache: false,
                processData: false,
                type: "POST",
                url: href,
                contentType: false,
                data: data,
                success: function (result) {
                    if (result.MessageTitle === "Exception") {
                        alert(result.MessageBody);
                        return false;
                    } else {
                        alert(result.MessageBody);

                        LoadPage(result.href);
                        if (result.IsPrint) {
                            window.open(result.printlink);

                        }

                    }

                },
                complete: function (jqXHR, textStatus) {

                }
            });
        }


    } catch (error) {
        alert(error);

    }
}

function Cancel(parameters, data) {
    $('#myModal').modal('hide');
    var renderBody = $('#detialsPage');
    renderBody.empty();

    if (parameters === "Cat") {
        CategoryLoad();
        //if ($('#CategoryId').val() != undefined)
        //{


        //}

    } else if (parameters === "SubCat") {
        // CategoryLoad();
        //if ($('#SubCategoryId').val() != undefined)
        //{
        SelectSubCategoryLoad();
        //}
    } else if (parameters === "Supplier") {
        SupplierLoad();
    } else if (parameters === "NewProduct") {
        NewProduct();
    }
}



function SubmitButtonOnclick() {
    if ($('#createBook').valid())
    {
        var brands = $('#MultiCategegory option:selected');
        var categorySelect = "";
        $(brands).each(function (index, brand) {
            categorySelect += $(this).val()+",";
        });
        if (categorySelect==="") {
            alert('Required add subject area');
            return;
        }
        var progressbar = $("#progressbar-5");
        var progressLabel = $(".progress-label");
        progressbar.show();
        var width = 0;
        var elem = document.getElementById("bar");
        var formData = new FormData();

        var bookdata = document.getElementById("BookdocumBase").files;

        var id = document.getElementById("Id").value;
        var EditionId = document.getElementById("EditionId").value;
        var Book_Title = document.getElementById("Book_Title").value;
        var ProgramId = document.getElementById("ProgramId").value;
        //var CategoryId = document.getElementById("SubjectArea_CategoryId").value;
        var CategoryId = categorySelect;
        var Author = document.getElementById("Author").value;
        var Description = document.getElementById("Description").value;
        var Published = document.getElementById("Published").checked;
        for (var i = 0; i < bookdata.length; i++) {
            formData.append("BookdocumBase", bookdata[i]);
        }

        //formData.append("coverfile", coverfile);

        formData.append("Id", id);
        formData.append("Book_Title", Book_Title);
        formData.append("EditionId", EditionId);
        formData.append("ProgramId", ProgramId);
        formData.append("SubjectArea_CategoryId", CategoryId);
        formData.append("Author", Author);
        formData.append("Description", Description);
        formData.append("Published", Published);
        var xhr = new XMLHttpRequest();
        xhr.upload.addEventListener('progress', onprogressHandler, false);
        xhr.open('POST', '/_ebook/UploadData', true);
        xhr.addEventListener("load", function (e) {
            // file upload is complete
            alert(xhr.responseText);
        });
        function onprogressHandler(evt) {
            var percent = evt.loaded / evt.total * 100;
            elem.style.width = percent + '%';
            elem.aria_valuenow = percent + '%';
            elem.innerHTML = percent * 1 + '%';

        }
        xhr.send(formData); // Simple!
    }


    //xhr.upload.onprogress = function(e)
    //{

    //    var percentComplete = Math.ceil((e.loaded / e.total) * 100);
    //    elem.style.width = percentComplete + '%';
    //    elem.aria_valuenow = percentComplete + '%';
    //    elem.innerHTML = percentComplete * 1 + '%';

    //};
    // xhr.send(formData);



}
function UploadComplete(evt) {
    try {
        if (evt.target.status == 200)
            alert("Logo uploaded successfully.");

        else
            alert(evt.error);
    } catch (e) {
        alert(evt.error);
    }

}

function UploadFailed(evt) {
    alert("There was an error attempting to upload the file.");

}

function upload() {

    var fileUpload = $("#BookdocumBase").get(0);
    var files = fileUpload.files;

    // Create FormData object

    var _data = $('#createBook').serialize();
    if ($('#createBook').valid()) {
        var fileData = new FormData();
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        $.ajax({
            cache: false,
            url: '/_ebook/UploadData',
            type: "POST",
            // Not to set any content header
            //processData: false,
            //contentType: true,// Not to process data
            data: _data,
            async: false,
            success: function (result) {
                if (result != "") {
                    LoadProgressBar(result); //calling LoadProgressBar function to load the progress bar.
                }
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
        function LoadProgressBar(result) {
            var progressbar = $("#progressbar-5");
            var progressLabel = $(".progress-label");
            progressbar.show();
            $("#progressbar-5").progressbar({
                //value: false,
                change: function () {
                    progressLabel.text(
                        progressbar.progressbar("value") + "%");  // Showing the progress increment value in progress bar
                },
                complete: function () {
                    progressLabel.text("Loading Completed!");
                    progressbar.progressbar("value", 0);  //Reinitialize the progress bar value 0
                    progressLabel.text("");
                    //progressbar.hide(); //Hiding the progress bar
                    var data = $('#createBook').serialize();
                    try {
                        $.ajax({
                            cache: false,
                            type: "POST",
                            url: '/_ebook/Create',
                            data: data,
                            success: function (data) {
                                alert(data);

                            },
                            complete: function (jqXHR, textStatus) {
                                //window.setTimeout(function () {window.location.href = "/UserAccount/Account";
                                //}, 3000);
                            }
                        });

                    } catch (e) {
                        alert(e);
                    }

                }
            });
            function progress() {
                var val = progressbar.progressbar("value") || 0;
                progressbar.progressbar("value", val + 1);
                if (val < 99) {
                    setTimeout(progress, 25);
                }
            }
            setTimeout(progress, 100);
        }
    }
    // Looping over all files and add it to FormData object

};
