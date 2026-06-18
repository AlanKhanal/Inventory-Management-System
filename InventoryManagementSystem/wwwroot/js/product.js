let editId = null;

// =====================
// GET ALL PRODUCTS
// =====================
async function loadProducts() {
    try {
        const res = await fetch(PRODUCT_API);
        const data = await res.json();

        const table = document.getElementById("productTable");
        table.innerHTML = "";

        data.forEach(p => {
            table.innerHTML += `
                <tr>
                    <td>${p.id}</td>
                    <td>${p.name}</td>
                    <td>${p.price}</td>
                    <td>${p.stock}</td>
                    <td>
                        <button class="btn btn-danger btn-sm"
                            onclick="deleteProduct(${p.id})">
                            Delete
                        </button>

                        <button class="btn btn-warning btn-sm"
                            onclick="editProduct(${p.id})">
                            Edit
                        </button>
                    </td>
                </tr>
            `;
        });

    } catch (err) {
        console.error("Error loading products:", err);
    }
}

// =====================
// ADD PRODUCT
// =====================
async function addProduct() {

    const name = document.getElementById("name").value;
    const price = Number(document.getElementById("price").value);
    const stock = Number(document.getElementById("stock").value);

    if (!name || isNaN(price) || isNaN(stock)) {
        alert("Please enter valid data");
        return;
    }

    const product = { name, price, stock };

    try {
        await fetch(PRODUCT_API, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(product)
        });

        clearForm();
        loadProducts();

    } catch (err) {
        console.error("Error adding product:", err);
    }
}

// =====================
// DELETE PRODUCT
// =====================
async function deleteProduct(id) {

    try {
        await fetch(`${PRODUCT_API}/${id}`, {
            method: "DELETE"
        });

        loadProducts();

    } catch (err) {
        console.error("Error deleting product:", err);
    }
}

// =====================
// EDIT PRODUCT (fill form)
// =====================
async function editProduct(id) {

    try {
        const res = await fetch(`${PRODUCT_API}/${id}`);
        const product = await res.json();

        document.getElementById("name").value = product.name;
        document.getElementById("price").value = product.price;
        document.getElementById("stock").value = product.stock;

        editId = id;

        toggleButtons(true);

    } catch (err) {
        console.error("Error fetching product:", err);
    }
}

// =====================
// UPDATE PRODUCT
// =====================
async function updateProduct() {

    const name = document.getElementById("name").value;
    const price = Number(document.getElementById("price").value);
    const stock = Number(document.getElementById("stock").value);

    if (!name || isNaN(price) || isNaN(stock)) {
        alert("Invalid input");
        return;
    }

    const updatedProduct = { name, price, stock };

    try {
        await fetch(`${PRODUCT_API}/${editId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(updatedProduct)
        });

        editId = null;

        clearForm();
        toggleButtons(false);
        loadProducts();

    } catch (err) {
        console.error("Error updating product:", err);
    }
}

// =====================
// CLEAR FORM
// =====================
function clearForm() {
    document.getElementById("name").value = "";
    document.getElementById("price").value = "";
    document.getElementById("stock").value = "";
}

// =====================
// TOGGLE ADD / UPDATE UI
// =====================
function toggleButtons(isEditMode) {

    const addBtn = document.getElementById("addBtn");
    const updateBtn = document.getElementById("updateBtn");

    if (isEditMode) {
        addBtn.style.display = "none";
        updateBtn.style.display = "inline-block";
    } else {
        addBtn.style.display = "inline-block";
        updateBtn.style.display = "none";
    }
}