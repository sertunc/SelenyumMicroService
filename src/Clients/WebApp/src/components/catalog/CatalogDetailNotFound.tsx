import { Card, CardContent, Typography } from "@mui/material";
import WarningIcon from "@mui/icons-material/Warning";

export default function CatalogDetailNotFound() {
  return (
    <Card>
      <CardContent>
        <div style={{ textAlign: "center" }}>
          <WarningIcon fontSize="large" color="warning" sx={{ mb: 1 }} />
        </div>
        <Typography variant="h5" component="div" align="center">
          Catalog Item Not Found
        </Typography>
        <Typography variant="body2" color="text.secondary" align="center">
          Please select another catalog item.
        </Typography>
      </CardContent>
    </Card>
  );
}
