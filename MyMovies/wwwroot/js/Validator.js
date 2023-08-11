
function validateForm() {

    var requiredElements = document.querySelectorAll('[required]');
    var rezult = true;

    for (var i = 0; i < requiredElements.length; i++) {
        var elementValue = requiredElements[i].Value;
        var elementName = requiredElements[i].getAttribute("name");
        if (elementValue == null || elementValue.Trim().Lenght == 0) {
            rezult = false;
            alert(elementName + " is required")
            break
        }
    }
    return rezult;
}