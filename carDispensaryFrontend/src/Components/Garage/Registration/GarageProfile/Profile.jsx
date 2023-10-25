import React, { useState, useEffect } from "react";
import { Container, Table, Button, Modal, Form } from "react-bootstrap";
import "./Profile.css"; 
import axios from "axios"; 
import { useNavigate } from "react-router-dom";

const Profile = () => {
    const [selectedRow, setSelectedRow] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [options, setOptions] = useState([]);
    const [garageName, setGarageName] = useState([]); 

    const navigate = useNavigate();

    useEffect(() => {
       
        const id = localStorage.getItem("GarageID")

        debugger;
        axios
            .get("http://localhost:63650/api/RequestHandler/Detail/1") // 

            .then((response) => {
        
                var option = response.data;
                const garage = option.map(name => name.GarageName);
                debugger;
                setGarageName(garage);
                console.log(options);
                setOptions(response.data);
             

            })
            .catch((error) => {
                console.error("Error fetching options:", error);
            });
    }, []);

    const handleAccept = async (rowId) => {

        debugger;
        let orderid = rowId;
        debugger;
        try {
           
            const response = await axios.put(`http://localhost:63650/api/RequestHandler/OrderAccept/${orderid}`);
            console.log('Data saved:', response.data);
        } catch (error) {
      
            console.error('Error saving data:', error);
        }
        debugger;
        navigate("/OrderDetail/${orderid}");

        localStorage.setItem("acceptorder", orderid)
    };

    const ShowOrderDetail = (rowId) => {
       

        
    };

    // const handleModalClose = () => {
    //     setSelectedRow(null);
    //     setShowModal(false);
    // };

    // ... rest of the component


  

    return (
        <div className="profile-container">
           
           
           
            <h1 className="profile-header">Profile</h1>
            <p className="profile-welcome">
                Welcome to {garageName ? garageName[0] : "Your Garage"}
            </p>
            <br/>
            <br/>
            <br/>
            <Container>
                <Table className="profile-table" striped bordered hover>
                    <thead>
                        <tr>
                            <th className="table-header">Options</th>
                            <th className="table-header">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {options.map((option) => (
                            <tr key={option.id}>
                                <td className="table-data"><h3>Order = {option.VehicleModel}-{option.VarientName }</h3></td>
                                <td className="table-data">
                                    <Button
                                        className="btn-accept"
                                        onClick={() => handleAccept(option.Id)}
                                    >
                                        Accept
                                    </Button>{" "}
                                    {/* <Button
                                        className="btn-deny"
                                        onClick={() => ShowOrderDetail(option.Id)}
                                    >
                                        Deny
                                    </Button> */}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>

                
            </Container>
        </div>
    );
};

export default Profile;