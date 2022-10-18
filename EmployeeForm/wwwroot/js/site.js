// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$().ready(function () {
    $("#signupform").validate({
             // in 'rules' user have to specify all the constraints for respective fields
             rules: {

                FirstName: {
                     required: true,
                     lettersonly:true,
                 },
                LastName: {
                     required: true,
                    lettersonly: true,
                 },
                 EmployeeAddress: {
                     required: true,
                 },
                 ContactNumber: {

                    required: true,
                    number: true,
                    maxlength:10,
                 },
                CreatePassword: {
                     required: true,
                  minlength:5,

                 },
                ConfirmPassword: {
                     required: true,
                     minlength: 5,
                     equalTo: "#password" //for checking both passwords are same or not
                 },
                 EmployeeWorkLocation:
                 {
                     required: true,
                 },
               DateofJoining:{
                    required: true,
                 },
                EmployeeAge: {
                    required: true,
                    number: true,
                },
                 EmployeeExperience: {
                    required: true,
                    number: true,
                },
             },
             // in 'messages' user have to specify message as per rules
             messages: {
                EmployeeAddress: {
                     required: " Please enter a Address",
                 },
                LastName: {
                     required: " Please enter a LastName",
                    lettersonly: "Only alphabets are valid"
                 },
                FirstName: {
                     required: " Please enter a FirstName",
                    lettersonly: "Only alphabets are valid"
                 },
                DateofJoining: {
                     required: " Please enter a date",
                 },
                ContactNumber: {
                     required: " Please enter a Phone Number",
                     maxlength: " Your number must not exceed 10 characters",

                 },
                CreatePassword: {
                     required: " Please enter a password",
                     minlength: " Your password must be consist of at least 5 characters"
                 },
                ConfirmPassword: {
                     required: " Please enter a password",
                     minlength: " Your password must be consist of at least 5 characters",
                     equalTo: " Please enter the same password as above"
                 },

                 EmployeeWorkLocation: {
                     required: "please select a field"
                 },
                 EmployeeAge:
                 {
                    required: "please enter agee"
                 },
                EmployeeExperience:
                {
                    required: "please enter agee"
                }
            },

         });

     });