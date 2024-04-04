import {
  Button,
  Card,
  Chip,
  CardHeader,
  CardMedia,
  CardContent,
  CardActions,
  IconButton,
  Typography,
} from "@mui/material";
import FavoriteIcon from "@mui/icons-material/Favorite";
import { Link } from "react-router-dom";
import { CatalogListViewModel } from "../models/CatalogListModel";

interface IProps {
  item: CatalogListViewModel;
}

export default function CatalogListItem(props: IProps) {
  const substringName = (name: string) => {
    if (name.length > 24) {
      return name.substring(0, 20) + "...";
    }
    return name;
  };

  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardHeader
        title={substringName(props.item.name)}
        action={
          <IconButton aria-label="settings">
            <FavoriteIcon />
          </IconButton>
        }
      />
      <Link
        style={{ color: "inherit", textDecoration: "inherit" }}
        to={`catalogdetail/${props.item.id}`}
      >
        <CardMedia
          component="img"
          height="194"
          image={props.item.pictureUri}
          alt={props.item.name}
        />
        <CardContent>
          <Typography variant="body2" color="text.secondary">
            {props.item.description}
          </Typography>
        </CardContent>
      </Link>
      <CardActions disableSpacing>
        <Chip color="primary" label={"$ " + props.item.price} />
        <Button
          color="secondary"
          variant="contained"
          size="small"
          style={{ marginLeft: "auto" }}
        >
          SEPETE EKLE
        </Button>
      </CardActions>
    </Card>
  );
}
