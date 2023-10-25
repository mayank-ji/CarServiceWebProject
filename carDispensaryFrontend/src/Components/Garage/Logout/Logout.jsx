import { useNavigate } from "react-router-dom";

const Logout = () =>
{
    const navigate = useNavigate();
    debugger;
    localStorage.removeItem("GarageID");

    localStorage.clear();

    navigate("/");
}

export default Logout;