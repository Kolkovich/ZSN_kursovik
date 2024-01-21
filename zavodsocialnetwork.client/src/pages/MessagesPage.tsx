import currentUser from "../scripts/reg_log.ts";
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
export default function MessagesPage(){

    if(currentUser.id != 0) {
        return <div className={"mainPage"}>
            <Box>
                <Grid item xs={12} md={6}>
                    <Typography sx={{mt: 4, mb: 2}} variant="h6" component="div">
                        Information about your profile:
                    </Typography>
                    <List>
                        <ListItem>
                            <ListItemText
                                primary={"Your id: " + currentUser.id}
                            />
                        </ListItem>
                        <ListItem>
                            <ListItemText
                                primary={"Your organisation: " + currentUser.organization}
                            />
                        </ListItem>
                        <ListItem>
                            <ListItemText
                                primary={"Your role: " + currentUser.role}
                            />
                        </ListItem>
                        <ListItem>
                            <ListItemText
                                primary={"Your phone: " + currentUser.phone}
                            />
                        </ListItem>
                    </List>
                </Grid>
            </Box>
        </div>
    }
}