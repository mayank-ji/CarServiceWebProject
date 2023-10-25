import "../Registration/Signup.css";
import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { library } from "@fortawesome/fontawesome-svg-core";
import { faEnvelope, faLocationCrosshairs, faUser, faUnlockAlt } from '@fortawesome/free-solid-svg-icons';
import { faMobileAlt } from '@fortawesome/free-solid-svg-icons';
import { faIdBadge } from '@fortawesome/free-solid-svg-icons';
import { useState } from "react";
import axios from 'axios';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';


library.add(faEnvelope, faUser, faUnlockAlt, faMobileAlt, faIdBadge, faLocationCrosshairs)

const Signup = () => {

    const [registrationResult, setRegistrationResult] = useState('');
    const [selectedForm, setSelectedForm] = useState('customer');
    const [CustomerDetail, setCustomerDetail] = useState({
        name: "",
        email: "",
        password: "",
        Mobile: "",
        License: "",
        Address: ""
    });
    const [GarageDetail, setGarageDetail] = useState(

        {
            name: "",
            password: "",
            Address: "",
            Mobile: "",
            License: ""
        }
    )


    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const customerData = 
            { 
                "CustName" : CustomerDetail.name,
                "CustEmail": CustomerDetail.email,
                "CustMobile": CustomerDetail.Mobile,
                "CustAddress": CustomerDetail.Address,
                "CustPassword":CustomerDetail.password


            }

            const garageData =
            {
                GarageName: GarageDetail.name,
                GarageMobile: GarageDetail.Mobile,
                GarageLocation: GarageDetail.Address,
                Password: GarageDetail.password,
                License:GarageDetail.License


            }

             const data = selectedForm === "garage" ? garageData : customerData;
            const apiUrl = selectedForm === "garage"
                ? 'http://localhost:63650/api/Garage/registration'
                : 'http://localhost:63650/api/Customer/Registration';

            try {
                const response =await axios.post(apiUrl, data);
                debugger;
                var resp = response.data.data;
                console.log(resp.Status);
                setRegistrationResult(JSON.stringify(resp.Message));
                console.log(registrationResult);
                
                    
            }
            catch (error) {
                
                console.error('Error making post request:', error);
            }


            // Clear form after submission
            setGarageDetail({
                name: '',
                password: '',
                Address: '',
                Mobile: '',
                License: ''
            });

            setCustomerDetail({
                name: '',
                email: "",
                password: '',
                Mobile: '',
                License: '',
                Address: ''
            })

        } catch (error) {
            console.error('Error submitting data:', error);
        }
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        if (selectedForm === 'garage') {
            setGarageDetail((prevData) => ({
                ...prevData,
                [name]: value
            }));
        } else {
            setCustomerDetail((prevData) => ({
                ...prevData,
                [name]: value
            }));
        }
    };



    return (
        <div  className="main-block">
            

            {/* <Popup trigger={<button> Trigger</button>} position="right center">
                <div>Popup content here !!</div>
            </Popup> */}
            <h1>Registration</h1>
            <hr />
            <div className="account-type">
                <input
                    type="radio"
                    value="garage"
                    id="radioTwo"
                    checked={selectedForm === "garage"}
                    onChange={() => setSelectedForm('garage')}
                    name="account"
                />
                <label htmlFor="radioTwo" className="radio">
                    Garage
                </label>

                <input
                    type="radio"
                    value="customer"
                    id="radioOne"
                    checked={selectedForm === "customer"}
                    onChange={() => setSelectedForm('customer')}
                    name="account"
                />

                <label htmlFor="radioOne" className="radio">
                    Customer
                </label>
            </div>


            <form onSubmit={handleSubmit}>
                {selectedForm === "garage" && (
                    <div>
                        <div>
                            <label For="name"
                                id="icon">
                                <FontAwesomeIcon icon={faUser} />
                            </label>
                            &nbsp;&nbsp;

                            <input
                                type="text"
                                name="name"
                                id="garagename"
                                value={GarageDetail.name}
                                placeholder="Name"
                                onChange={handleInputChange}
                                required />
                        </div>

                        <div>
                            <label
                                For="password"
                                id="icon">
                                <FontAwesomeIcon icon={faUnlockAlt} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="password"
                                name="password"
                                id="garagepassword"
                                placeholder="Password"
                                value={GarageDetail.password}
                                onChange={handleInputChange}
                                required />
                        </div>
                        <div>
                            <label
                                For="Mobile "
                                id="icon">
                                <FontAwesomeIcon icon={faMobileAlt} />
                            </label>
                            &nbsp;&nbsp;

                            <input
                                type="text"
                                name="Mobile"
                                id="garageMobile "
                                placeholder="Mobile "
                                value={GarageDetail.Mobile}
                                onChange={handleInputChange}
                                required />
                        </div>
                        <div>
                            <label
                                For="License"
                                id="icon">
                                <FontAwesomeIcon icon={faIdBadge} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="text"
                                name="License"
                                id="garageLicense"
                                placeholder="License"
                                value={GarageDetail.License}
                                onChange={handleInputChange}
                                required />
                        </div>
                        <div>
                            <label
                                For="Address"
                                id="icon">
                                <FontAwesomeIcon icon={faLocationCrosshairs} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="text"
                                name="Address"
                                id="garageAddress"
                                placeholder="Address"
                                value={GarageDetail.Address}
                                onChange={handleInputChange}
                                required />
                        </div>
                    </div>

                )}

                {selectedForm === "customer" && (
                    <div>
                        <div>
                            <label For="name"
                                id="icon">
                                <FontAwesomeIcon icon={faUser} />
                            </label>&nbsp;&nbsp;

                            <input
                                type="text"
                                name="name"
                                id="garagename"
                                value={CustomerDetail.name}
                                placeholder="Name"
                                onChange={handleInputChange}
                                required />
                        </div>
                        <div>

                            <label
                                For="email"
                                id="icon">
                                <FontAwesomeIcon
                                    icon={faEnvelope} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="text"
                                name="email"
                                id="customeremail"
                                placeholder="Email"
                                value={CustomerDetail.email}
                                onChange={handleInputChange}
                                required />
                        </div>

                        <div>
                            <label
                                For="password"
                                id="icon">
                                <FontAwesomeIcon icon={faUnlockAlt} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="password"
                                name="password"
                                id="customerpassword"
                                placeholder="Password"
                                value={CustomerDetail.password}
                                onChange={handleInputChange}
                                required />
                        </div>
                        <div>
                            <label
                                For="Mobile "
                                id="icon">
                                <FontAwesomeIcon icon={faMobileAlt} />
                            </label>
                            &nbsp;&nbsp;

                            <input
                                type="text"
                                name="Mobile"
                                id="customerMobile "
                                placeholder="Mobile "
                                value={CustomerDetail.Mobile}
                                onChange={handleInputChange}
                                required />
                        </div>

                        <div>
                            <label
                                For="Address"
                                id="icon">
                                <FontAwesomeIcon icon={faLocationCrosshairs} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="text"
                                name="Address"
                                id="customerAddress"
                                placeholder="Address"
                                value={CustomerDetail.Address}
                                onChange={handleInputChange}
                                required />
                        </div>
                    </div>

                )}


                <button className="button" type="submit">Submit</button>
            </form>
        </div>

    );
}

export default Signup;

