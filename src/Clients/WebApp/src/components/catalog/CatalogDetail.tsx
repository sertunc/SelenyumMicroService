import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";
import CommonStyles from "../../CommonStyles";
import {
  Button,
  Card,
  CardHeader,
  CardMedia,
  CardContent,
  Typography,
  CardActions,
  Chip,
  IconButton,
} from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { CatalogItemModel } from "../../models/CatalogItemModel";

export default function CatalogDetail() {
  const navigate = useNavigate();
  const { id } = useParams();

  const [model, setModel] = useState<CatalogItemModel>({
    id: "",
    name: "",
    description: "",
    pictureUri: "",
    price: 0,
    catalogType: "",
  });

  useEffect(() => {
    (async () => {
      const response = await axios.get(`catalog/items/${id}`);

      if (response.data.isSuccessful === false) {
        navigate("/catalogdetailnotfound");
      } else {
        setModel(response.data.data);
      }
    })();
  }, []);

  return (
    <Card>
      <CardHeader
        title={model.name}
        action={
          <IconButton aria-label="settings">
            <FavoriteIcon />
          </IconButton>
        }
      />
      <CardMedia
        component="img"
        height="500"
        image={model.pictureUri}
        alt={model.name}
      />
      <CardContent>
        <Typography variant="body2" color="text.secondary">
          {model.description}
        </Typography>
      </CardContent>
      <CardActions disableSpacing>
        <Chip color="primary" label={"$ " + model.price} />
        <Button
          color="secondary"
          variant="contained"
          size="small"
          style={CommonStyles.addToBasketButton}
        >
          SEPETE EKLE
        </Button>
      </CardActions>
    </Card>
  );
}
