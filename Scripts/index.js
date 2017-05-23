$(function () {
    $('#MyForm').submit(function (event) {
        event.preventDefault();
        
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (result) {
                    $('#result').html(result);
                },
                fail: function (result) {
                    console.log(result);
                }
            });
        
        return false;
    });
});