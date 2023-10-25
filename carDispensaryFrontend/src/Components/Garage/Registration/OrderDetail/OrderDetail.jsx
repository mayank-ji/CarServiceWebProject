import React, { useState, useEffect } from "react";
import axios from "axios"; // Import Axios



const OrdDetail = () => {
   
    
    const [selectedButton, setSelectedButton] = useState([]);
    const [orderDetail, setOrderDetail] = useState({
        "Manufacturing": "",
        "Registration": "",
        "Odometer": "",
        "Customer Name": "",
        "email": "",
        "mobile": "",
        "address": "",
        "servicename": "",
        "carmodel": "",
        "modelvarient": "",
        "serviceprice": "",
        "garagename": "",

    });
    const [orderData, setOrderData] = useState([])
    const [customerName, setCustomerName] = useState([]);

    useEffect(() => {
       
        const orderid = localStorage.getItem("acceptorder");
        axios
            .get(`http://localhost:63650/api/Order/GetOrderDetail/${orderid}`)

            .then((response) => {
                const orderData = response.data;


                
          
                setOrderData(orderData[0]);
             
                console.log(orderData[0]);
             
                localStorage.setItem("Orderdata", JSON.stringify(orderData[0]))




            })
            .catch((error) => {
             
                console.error("Error fetching customer data:", error);
            });

    },)


    const saveAndNext = async () => {
       

        try {
            // Create a copy of the orderData state to modify
            const updatedOrderData = { ...orderData };

            // Update the properties in the copied orderData object
            updatedOrderData.ManufacturingYear = orderDetail.Manufacturing;
            updatedOrderData.CarRegistrationNo = orderDetail.Registration;
            updatedOrderData.OdometerReading = orderDetail.Odometer;
            updatedOrderData.GarageName = orderDetail.garagename;
            updatedOrderData.ServiceName = orderDetail.servicename;
            updatedOrderData.ServicePrice = orderDetail.serviceprice;
            updatedOrderData.VarientName = orderDetail.VarientName;

            const id = updatedOrderData.OrderId;
            console.log(id);
            console.log(updatedOrderData);

          
            const response = await axios.put(`http://localhost:63650/api/Order/editOrder/${id}`, updatedOrderData);
       

            console.log('Data saved:', response.data);
        } catch (error) {
            console.error('Error saving data:', error);
        }
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        {
            setOrderDetail((prevData) => ({
                ...prevData,
                [name]: value
            }));

        }
    };




    const detail = (localStorage.getItem("Orderdata"))
  



    return (
        <div className="ml-5 mr-5">

            <div className="text-center mb-3">
                <h1>Order Detail</h1>
            </div>
          <br/><br/>

            <form>
                <h4>Car Detail</h4>
                <div className="form-row">
                    <div className="col">
                        <input
                            name="Manufacturing"
                            className="form-control mb-2"
                            placeholder="Manufacturing Year"
                            value={orderDetail.Manufacturing}
                            onChange={handleInputChange}
                        />
                        <input
                            name="Odometer"
                            className="form-control mb-2"
                            placeholder="Odometer Reading"
                            value={orderDetail.Odometer}
                            onChange={handleInputChange}
                        />
                   

                    
                        <input
                            name="carmodel"
                            type="text"
                            class="form-control mb-2"
                            placeholder="Car Model"
                            value={orderData.VehicleModel}
                            onChange={handleInputChange}
                        />
                        <input
                            name="Registration"
                            value={orderDetail.Registration}
                            className="form-control mb-2"
                            placeholder="Registration No."
                            onChange={handleInputChange}
                        />
                    </div>
                </div>
            </form>

            <div className="ml-5 mr-5">
                {/* ... Rest of your JSX ... */}
                <form>
                    <h4 class="mt-4">Customer details</h4>
                    <div class="form-row ">
                        <div class="col ">
                            <input
                                name="Customer Name"
                                class="form-control mb-2"
                                placeholder="Customer Name"
                                value={orderData.CustomerName}
                                onChange={handleInputChange}
                            />
                            <input
                                type="email"
                                name="email"
                                class="form-control mb-2"
                                placeholder="E-mail"
                                value={orderData.CustEmail}
                                onChange={handleInputChange}
                            />
                        </div>

                        <div class="col">
                            <input
                                type="tel"
                                name="mobile"
                                class="form-control mb-2"
                                placeholder="Mobile No."
                                value={orderData.CustMobileNo}
                                onChange={handleInputChange}
                            />
                            <input
                                type="text"
                                name="address"
                                class="form-control mb-2"
                                placeholder="Address"
                                value={orderData.CustAddress}
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>
                </form>

                <form>
                    <h3>Order details</h3>
                    <div class="form-row ">
                        <div class="col ">
                            <input
                                name="servicename"
                                type="text"
                                class="form-control mb-2"
                                placeholder="Service Name"
                                value={orderData.ServiceName}
                                onChange={handleInputChange}
                            />
                           

                            <input
                                name="modelvarient"
                                type="text"
                                class="form-control mb-2"
                                placeholder="Model Varient"
                                value={orderData.VarientName}
                                onChange={handleInputChange}
                            />
                            <input
                                name="serviceprice"
                                type="text"
                                class="form-control mb-2"
                                placeholder="Service Price"
                                value={orderData.ServicePrice}
                                onChange={handleInputChange}
                            />
                        </div>

                        <div>
                            <input
                                name="garagename"
                                type="text"
                                class="form-control mb-2"
                                placeholder="Garage Name"
                                value={orderDetail.garagename}
                                onChange={handleInputChange}
                            />
                        </div>


                    </div>

                    <ul class="nav nav-pills justify-content-end">
                        <li class="nav-item">
                            <button onClick={saveAndNext} className="btn btn-primary">Save Next</button>
                        </li>
                    </ul>
                </form>

                <hr />
            </div>
            <div>

            </div>

        </div>
    );
};

export default OrdDetail;