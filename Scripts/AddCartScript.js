console.log("Javascript(AddCart) connected!!")

var selectedProduct = document.getElementById('myid');
console.log(selectedProduct)
selectedProduct.addEventListener('change', getElement);


var hidden = document.getElementById('hidden');
console.log(selectedProduct.value)
console.log(hidden)

function getElement() {
    console.log(selectedProduct.value);
    hidden.value = selectedProduct.value;
}