function AddDetail() {
    $.ajax({
        url: "/AdminController/AddDetailById",
        type: "post",
        contentType: 'application/x-www-form-urlencoded',
        data: { id: 1 },
        success: function (result) {
            AddHtmlDetail(result);
            console.log(result);
        }
    });

    function AddHtmlDetail(detail) {
        let mainDiv = document.getElementById("details");

        let div_Card = document.createElement("div");
        div_Card.classList.add("card", "department-card", "text-center", "m-1", "detail");
        div_Card.id = detail.id + "jsDetail";

        let div_Card_Body = document.createElement("div");
        div_Card_Body.className = "card-body";

        let DetailName = document.createElement("h5");
        DetailName.className = "card-title";
        DetailName.innerHTML = detail.name;

        let DetailInfo = document.createElement("p");
        DetailInfo.className = "card-text";
        DetailInfo.innerHTML = detail.info;

        let DetailManual = document.createElement("h6");
        DetailManual.classList.add("card-subtitle", "mb-2", "text-muted");
        DetailManual.innerHTML = detail.manual;

        let DeleteButt = document.createElement("a");
        DeleteButt.classList.add("btn-danger", "w-75", "rounded-pill", "mw-100", "mb-1", "showDetail");
        DeleteButt.innerHTML = "Удалить";
        DeleteButt.href = 'javascript:void(0)';

        let detailsCounts = document.createElement("input");
        detailsCounts.className = "form-control";
        detailsCounts.name = "detailsCounts";
        detailsCounts.type = "number";

        let hiddenId = document.createElement("input");
        hiddenId.value = detail.id;
        hiddenId.type = "hidden";
        hiddenId.name = "detailsId";

        div_Card_Body.appendChild(DetailName);
        div_Card_Body.appendChild(DetailInfo);
        div_Card_Body.appendChild(DetailManual);
        div_Card_Body.appendChild(DeleteButt);
        div_Card_Body.appendChild(detailsCounts);
        div_Card_Body.appendChild(hiddenId);

        div_Card.appendChild(div_Card_Body);

        mainDiv.appendChild(div_Card);
    };
}

$(document).on("click", ".showDetail", function () { DeleteDetailFromAssem($(this).closest(".detail").attr("id")); });


function DeleteDetailFromAssem(id) {
    $.ajax({
        url: "/AdminController/DeleteDetailFromAssem",
        type: "post",
        success: function () {
            RemoveHtmlDetail(id);
            console.log(id);
        }
    });

    function RemoveHtmlDetail(id) {
        let mainDiv = document.getElementById("details");

        let div_Card = document.getElementById(id);

        mainDiv.removeChild(div_Card);
    };
}