const domain = "https://localhost:7101/"; 



//  async function getUsers()
// {
//     const response = await fetch("https://localhost:7101/api/User");
//     if(response.status == 200)
//     {
//         return response.json();
//     }
//     if (response.status == 404)
//     {    
//         console.log("Page not found!");
//         return null;
//     }
    
    
    
    // //.then(function(response){
    //     if (response.status == 200){
    //         return response.json();
    //     }
    //     if (response.status == 404){
    //         alert("Page not Found");
    //     }
    // }).then(responseData =>{
    //     users = responseData;

    // }).catch(error =>{
    //     console.log(error);
    // });

//}










async function getUsers()
{
    
    const response= await fetch("https://localhost:7101/api/User")
    if (response.status == 200){
        return response.json();
    }
    if (response.status == 404){
        
        return null;
    }
    
}


async function addProduct(pdata) {

    const response = await fetch("https://localhost:7101/api/Product",{
        method: "POST",
        headers:{
            "Content-Type":"multipart/form-data",
            "Accept": "*/*"
            
        },
        body: pdata
    });
    if (response.status == 200){
        return response.json();
    }
    if (response.status ==404){
        alert("Page not found!");
        return null;
    }
}


async function addUser(data)
{
    const response= await fetch("https://localhost:7101/api/User",
    {
        method: "POST",
        headers:{
            "Content-Type":"application/json",
            "Accept": "*/*"
        },
        body: JSON.stringify(Object.fromEntries(data))
    });

    if (response.ok)
    {
        return response.json();
    }
    else
    {
        alert(response.status);
        return null;
    }
    
}

async function getRoles()
{
    const response = await fetch("https://localhost:7101/api/Role")
    
        if(response.status == 200){
            return response.json();
        }

        if (response.status ==404){
            alert("Page not found!");
            return null;
        }
    
};

async function getProducts() 
{
    const response= await fetch("https://localhost:7101/api/Product")    
    console.log(response)
    if(response.ok){
        return response.json();
    }
    if (response.status ==404)
    {
        alert("Page not found");
        return null;
        
    }
}

async function getOrders()
{
    const response = await fetch("https://localhost:7101/api/Order")
    if(response.ok)
    {
        return response.json();
    }
    if (response.status ==404)
    {
        alert("Page not found");
        return null;
    }
    
}



async function addOrder(data)
{
    const response= await fetch("https://localhost:7101/api/Order",
    {
        method: "POST",
        headers:{
            "Content-Type":"application/json",
            "Accept": "*/*"
        },
        body: JSON.stringify(Object.fromEntries(data))
    });

    if (response.ok)
    {
        return response.json();
    }
    else
    {
        alert(response.status);
        return null;
    }
    
}






// async function getProducts()
//         {
//             const request =new XMLHttpRequest();
//             request.onload = function()
//             {
//                 let data = JSON.parse(request.responseText);
//                 for(let i=0; i < data.length;i++)
//                 {
//                     let product = data[i];
//                     let newRow = document.createElement("tr");
//                     newRow.innerHTML=`
//                     <td>${product.id}</td>
//                     <td>${product.name}</td>
//                     <td>
//                         <a href="${"https://localhost:7101/" + product.photo}">${product.photo}</a>
//                     </td>
//                     <td>${product.price}</td>
//                     <td>${product.size}</td>
//                     <td>${product.quantity}</td>                    
//                     `;
//                     let tbodyElement = document.getElementById("products");
//                     tbodyElement.appendChild(newRow);
//                 }
//             }
//             request.open("GET", "https://localhost:7101/api/Product")
//             request.send();
//         }