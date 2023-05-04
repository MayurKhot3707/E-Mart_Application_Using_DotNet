import React from 'react';
import './Order.css';


const Order =() =>{
    return (
        <div>
        <div className="order-management">
          {/* <h1>Your Orders</h1> */}
          
          
          
          <div class="container2">
               <center> 
                <nav class="nav">
               <div class="container-fluid">
                  <a class="navbar-brand" href="#"><h1>Your Order</h1></a>
                 <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"></input>
                 <button className="btn btn-outline-success" type="submit">Search</button>
                 </div></nav></center></div>
                 <br/>
                 <center>
                 <div class="row">
                     <div class="col-md-4">Order</div>
                     <div class="col-md-4">Buy Now</div>
                     <div class="col-md-4">Cancelled</div>
                </div>
                </center>
    
       <table>
          <thead>
            <tr>
              <th> <p>ORDER PLACED<br/>23 feb 2023</p> </th>
              <th>  <p>TOTAL<br/>1099/-</p></th>
              <th><p>SHIP TO<br/>Pooja Kshirsagar</p> </th>
              <th><p>Order # 407-00123614-4789918<br/>View order details<select> <option>Invoice</option>
                <option>order summary</option></select></p>  </th>
            </tr>
          
            <tr>
              <th>
              <div className="fivthdiv">
                   <p><b>Arriving Date</b><br/>not yet dispatched</p> 
                   <img src="/Image/kurti.jpeg" width="100" height="100"/>
              </div>
              </th>
              <th><p>Egrecia Fashion Women's & hoodies girls top & kurti ,<br/>stylish crop top Akj hg oiuytfrfghb lkjhgf ztyghbn  luytrd </p>  
              </th>
              <th></th>
              <th> <button class="button button2">Track Package</button><br/><br/>
                <button class="button button3">click here</button>
               </th>
            </tr>
          
            
          </thead>
         
            </table>
            </div>
       
         </div>
 
            
            

      )
}

  
export default Order

