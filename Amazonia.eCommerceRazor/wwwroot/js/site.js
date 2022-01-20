// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {

    var popoverTemplate = ['<div class="timePickerWrapper popover">',
        '<div class="arrow"></div>',
        '<div class="popover-content">',
        '</div>',
        '</div>'].join('');

    var content = ['<div class="timePickerCanvas">asfaf asfsadf</div>',
        '<div class="timePickerClock timePickerHours">asdf asdfasf</div>',
        '<div class="timePickerClock timePickerMinutes"> asfa </div>',].join('');


    $('#elemento').popover({
        selector: '[rel=popover]',
        trigger: 'click',
        content: content,
        template: popoverTemplate,
        placement: "bottom",
        html: true
    });
});