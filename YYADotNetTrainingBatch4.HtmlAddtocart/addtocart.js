const tblBlog = "blogs";
let blogId = null;
Read();

getProductList();

function Read() {
    const data = fetch('https://fakestoreapi.com/products')
        .then(res => res.json())
        .then(json => console.log(json))
}

// var myModal = document.getElementById('addFormModal')
// var myInput = document.getElementById('myInput')

// myModal.addEventListener('addForm', function () {
//   myInput.focus()
// })

$('#btnSave').click(function () {
    const product = $('#txtProduct').val();
    const category = $('#txtCategory').val();
    const price = $('#txtPrice').val();
    const image = $('#productImage').val();

    // const fileInput = document.getElementById('productImage');

    // if (fileInput.files && fileInput.files[0]) {
    //     // A file has been selected
    //     const fileName = fileInput.files[0].name; // Get the file name
    //     const fileSize = fileInput.files[0].size; // Get the file size
    //     console.log("File Name:", fileName);
    //     console.log("File Size:", fileSize);
    // } else {
    //     console.log("No file selected");
    // }

    if (blogId === null) {
        createBlog(product, category, price,image);
    } else {
        updateBlog(blogId, product, category, price);
        blogId = null;
    }

    getProductList();
})

function createBlog(product, category, price,image) {
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        product: product,
        category: category,
        price: price,
        image : image
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    // localStorage.setItem("blogs", requestModel);

    successMessage("Saving Successful.");
    // clearControls();
}

function updateBlog(id, title, author, content) {}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}


function successMessage(message) {
    alert(message);
}

function errorMessage(message) {
    alert(message);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <tr>
            <td>
                <button type="button" class="btn btn-warning" onclick="editBlog('${item.id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
            </td>
            <td>${++count}</td>
            <td>${item.title}</td>
            <td>${item.author}</td>
            <td>${item.content}</td>
        </tr>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}

function createProductCard(product) {
    // Create the card element
    const card = document.createElement('div');
    card.classList.add('product-card'); // Add a class for styling

    // Create elements for title, image, and description (replace with your data)
    const title = document.createElement('h3');
    title.textContent = product.title;

    const image = document.createElement('img');
    image.src = product.imageUrl; // Set image source based on your data

    const description = document.createElement('p');
    description.textContent = product.description;

    // Append elements to the card
    card.appendChild(title);
    card.appendChild(image);
    card.appendChild(description);

    // Return the created card element
    return card;
}

function getProductList() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';
    lst.forEach(item => {
        const htmlRow = `
        <div class="col-3 mb-3">
        <div class="card p-0">
        <div class="card-header">${item.product}</div>
        <div class="card-body">
            <img src="${item.image}" class="card-img-top p-0"></img>
            <p>${item.category}</p>
            <p>${item.price}</p>
        </div>
        <div class="card-footer d-flex justify-content-between">
            <button type="button" class="btn btn-primary">Add</button>
            <button type="button" class="btn btn-danger">View</button>
        </div>
        </div>
    </div>
        `;
        htmlRows += htmlRow;
    });

    $('#product-container').html(htmlRows);
}