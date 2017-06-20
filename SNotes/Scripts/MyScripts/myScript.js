$(document).ready(function() {


    //$("input[type='text'], textarea").attr('spellcheck', false);
    $(".editableDivs").attr('spellcheck', false);

    $(function() {

        $('li').each(function() {

            var noteBoxHeight = $(".noteBox", this).outerHeight();
            var titleHeight = $(".noteTitle", this).outerHeight();
            var noteLabelHeight = $(".noteLabel", this).outerHeight();
            var noteFooterHeight = $(".noteFooter", this).outerHeight();

            $(".noteLabel").css({ bottom: noteFooterHeight });

            $(".editableDivs", this).outerHeight(noteBoxHeight - noteLabelHeight - noteFooterHeight);

            var editableDivsHeight = $(".editableDivs", this).outerHeight();

            $(".noteContent", this).outerHeight(editableDivsHeight - titleHeight);

        });
    });


    //$('#editLabelsToggle').click(function() {

    //    $("#editLabelInPartial, #deleteLabelInPartial").toggleClass("showLabelEditor hideLabelEditor");

    //});


    $('#editLabelsToggle').click(function () {
        if ($('#editLabelInPartial, #deleteLabelInPartial').css('display') == 'none') {
            $('#editLabelInPartial, #deleteLabelInPartial').css('display', 'block');
            $('#editLabelsToggleWrapper').css('background', 'red');
        }
        else {
            $('#editLabelInPartial, #deleteLabelInPartial').css('display', 'none');
            $('#editLabelsToggleWrapper').css('background', 'orange');
        }
    });


    
    $(function () {

        $('textarea').each(function () {

            if (this.clientHeight < this.scrollHeight) { this.style.height = this.scrollHeight + 'px' };

        });
    });


    $(".noteContent, .noteTitle").on("click",
        function () {

            var parent = $(this).closest('.noteBox');

            if ($('#temporaryId').length) {

            } else {

                var clone = parent.clone();

                clone.appendTo(".notes").addClass("expand");
                clone.attr('id', 'temporaryId');
                clone.find(".editableDivs").addClass(".expandEditableDivs");

                var noteBoxHeight = $(".expand").outerHeight();
                var titleHeight = $(".expand").find(".noteTitle").outerHeight();
                var noteLabelHeight = $(".expand").find(".noteLabel").outerHeight();
                var noteFooterHeight = $(".expand").find(".noteFooter").outerHeight();

                $(".expand").find(".noteLabel").css({ bottom: noteFooterHeight });

                $(".expand").find(".editableDivs").outerHeight(noteBoxHeight - noteLabelHeight - noteFooterHeight);

                var editableDivsHeight = $(".expand").find(".editableDivs").outerHeight();
                $(".expand").find(".noteContent").outerHeight(editableDivsHeight - titleHeight);

            };
       

            $("body").click(function (e) {

                if ($(e.target).closest("#temporaryId").length) {
                    return false;
                }
                else {
                    $("#temporaryId, this").remove();

                    $(".expand").removeClass("expand");
                    $(".expandTextarea").removeClass("expandTextarea");

                    $("#temporaryId").removeAttr("id");
                }

            });

            $(".noteBox").click(function (event) {

                event.stopPropagation();

            });

        });
});