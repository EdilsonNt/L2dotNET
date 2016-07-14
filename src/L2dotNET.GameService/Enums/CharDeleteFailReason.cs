namespace L2dotNET.GameService.Enums
{
    public enum CharDeleteFailReason
    {
        ///<summary>You have failed to delete the character.</summary>
        DeletionFailed = 1,
        ///<summary>You may not delete a clan member. Withdraw from the clan first and try again.</summary>
        YouMayNotDeleteClanMember = 2,
        ///<summary>Clan leaders may not be deleted. Dissolve the clan first and try again.</summary>
        ClanLeadersMayNotBeDeleted = 3
    }
}