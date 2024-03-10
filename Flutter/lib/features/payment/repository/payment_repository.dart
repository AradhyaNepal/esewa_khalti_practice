import 'package:base_repository_bya2/export.dart';

class PaymentRepository extends BaseRepository {
  PaymentRepository()
      : super(repositoryDetails: RepositoryDetails(tokenNeeded: false));

  Future<String> getPaymentDetails() async {
    return get(RequestInput(
      url: "URL",
      parseJson: (response) {
        return response["data"]["PaymentDetails"];
      },
    ));
  }
}
