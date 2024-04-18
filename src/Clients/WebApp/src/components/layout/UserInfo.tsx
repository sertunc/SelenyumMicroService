import { useUser } from "../../contexts/UserContext";
import { UserModel } from "../../models/UserModel";
import { useNavigate } from "react-router-dom";
import { Badge, Button, IconButton } from "@mui/material";

import ShoppingCartIcon from "@mui/icons-material/ShoppingCart";
import LogoutIcon from "@mui/icons-material/Logout";

export default function UserInfo() {
  const navigate = useNavigate();

  const { user, setUserInfo, totalItems } = useUser();

  const handleSignInClick = () => {
    navigate("/signin");
  };

  const handleLogoutClick = () => {
    localStorage.removeItem("user");
    setUserInfo(new UserModel("", ""));
    navigate("/");
  };

  const handleUserProfileClick = () => {
    navigate("/userprofile");
  };

  return user?.token === "" ? (
    <Button color="inherit" onClick={handleSignInClick}>
      Hello, sign in
    </Button>
  ) : (
    <>
      <Button color="inherit" onClick={handleUserProfileClick}>
        Hello, {user?.userName}
      </Button>
      <IconButton color="inherit">
        <Badge badgeContent={totalItems()} color="secondary">
          <ShoppingCartIcon />
        </Badge>
      </IconButton>
      <IconButton color="inherit" onClick={handleLogoutClick}>
        <LogoutIcon />
      </IconButton>
    </>
  );
}
