import Card from "@mui/material/Card";
import CardHeader from "@mui/material/CardHeader";
import CardMedia from "@mui/material/CardMedia";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";
import Typography from "@mui/material/Typography";
import { CatalogItemViewModel } from "../models/CatalogItemViewModel";
import { Button, Chip } from "@mui/material";

interface IProps {
  item: CatalogItemViewModel;
}

export default function CatalogListItem(props: IProps) {
  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardHeader title={props.item.name} />
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
