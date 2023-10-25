import { React, useState } from "react";
import "../Login/Login.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import {
    faEnvelope,
    faLocationCrosshairs,
    faUser,
    faUnlockAlt, faMobileAlt, faIdBadge,
} from "@fortawesome/free-solid-svg-icons";
import axios from "axios";
import { useNavigate } from "react-router-dom";


library.add(
    faEnvelope,
    faUser,
    faUnlockAlt,
    faMobileAlt,
    faIdBadge,
    faLocationCrosshairs
);

const Login = () => {

    const navigate = useNavigate();

    const [selectedForm, setSelectedForm] = useState("customer");
    const [garageData, setGarageData] = useState([]);
    const [CustomerDetail, setCustomerDetail] = useState({
        email: "",
        password: "",
    });
    const [GarageDetail, setGarageDetail] = useState({
        Mobile: "",
        password: "",
    });
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const customerData = {
                CustEmail: CustomerDetail.email,
                CustPassword: CustomerDetail.password,
            };

            const garageData = {
                GarageMobile: GarageDetail.Mobile,
                Password: GarageDetail.password,
            };

            const data = selectedForm === "garage" ? garageData : customerData;

            const custemail = customerData.CustEmail;
            const password = customerData.CustPassword;

            const GarageMobile = GarageDetail.Mobile;
            const Password = GarageDetail.password;

                                                                 //get(`http://localhost:63650/api/GarageToken/Get/${GarageMobile}/${Password}`);
            if (selectedForm === "garage") {
                debugger;                                    //api/Garage/login
                try {
                    const response = await axios.post(`http://localhost:63650/api/Garage/login`,garageData);
                    debugger;
                    const garageToken = response.data;

                    debugger;
                    sessionStorage.setItem("GarageToken", garageToken);
                    debugger;
                    if (garageToken != null) {

                        navigate("/Profile");

                    }



                } catch (error) {
                    console.error("Error making post request:", error);
                }
            
            }

            else {

                try {
                    const response = await axios.get("http://localhost:63650/api/CustomerToken/Get/" + custemail + "/" + password);
                    debugger;
                    const customerToken = response.data;
                    localStorage.setItem("customerToken", customerToken)

                       if (customerToken != null) {
                        
                        navigate("/Home");

                       }



                } catch (error) {
                    console.error("Error making post request:", error);

                }
            }


    // Clear form after submission
    setGarageDetail({
        Mobile: "",
        password: "",
    });

    setCustomerDetail({
        email: "",
        password: "",
    });

} catch (error) {
    console.error("Error submitting data:", error);
}
    };

const handleInputChange = (event) => {
    const { name, value } = event.target;
    if (selectedForm === "garage") {
        setGarageDetail((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    } else {
        setCustomerDetail((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    }
};



return (
    <div className="main">
        <div style={{ margin: "100px 700px" }} className="mainblock">
            <h1>Login</h1>
            <hr />
            <div className="account-type">
                <input
                    type="radio"
                    value="garage"
                    id="radioTwo"
                    checked={selectedForm === "garage"}
                    onChange={() => setSelectedForm("garage")}
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
                    onChange={() => setSelectedForm("customer")}
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
                            <label For="Mobile " id="icon">
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
                                required
                            />
                        </div>
                        <div>
                            <label For="password" id="icon">
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
                                required
                            />
                        </div>
                    </div>
                )}

                {selectedForm === "customer" && (
                    <div>
                        <div>
                            <label For="email" id="icon">
                                <FontAwesomeIcon icon={faEnvelope} />
                            </label>
                            &nbsp;&nbsp;
                            <input
                                type="text"
                                name="email"
                                id="customeremail"
                                placeholder="Email"
                                value={CustomerDetail.email}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                        <div>
                            <label For="password" id="icon">
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
                                required
                            />
                        </div>
                    </div>
                )}
                <button className="button" type="submit">
                    Submit
                </button>
            </form>
        </div>
    </div>
);
};

export default Login;